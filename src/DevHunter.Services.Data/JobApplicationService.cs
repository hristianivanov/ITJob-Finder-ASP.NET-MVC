namespace DevHunter.Services.Data
{
    using System.Linq.Expressions;
    using System.Web;

    using Microsoft.EntityFrameworkCore;

    using DevHunter.Common;
    using DevHunter.Data;
    using DevHunter.Data.Models;

    using Interfaces;
    using Web.ViewModels.JobApplication;
    using DevHunter.Data.Models.Enums;

    public class JobApplicationService : IJobApplicationService
    {
        private readonly DevHunterDbContext context;

        public JobApplicationService(DevHunterDbContext context)
        {
            this.context = context;
        }

        public async Task<string> ApplyJobOfferAsync(JobApplicationFormModel model, Guid jobOfferId, Guid userId)
        {
            ArgumentNullException.ThrowIfNull(model);

            bool jobOfferExists = await this.context.JobOffers
                .AsNoTracking()
                .AnyAsync(jobOffer => jobOffer.Id == jobOfferId);

            if (!jobOfferExists)
            {
                throw new InvalidOperationException("Job offer does not exist.");
            }

            var application = new JobApplication
            {
                Email = model.Email,
                CandidateName = model.CandidateName,
                MotivationalLetter = model.MotivationalLetter,
                JobOfferId = jobOfferId
            };

            if (userId != Guid.Empty)
            {
                var userApplication = new UserJobApplications
                {
                    JobApplicationId = application.Id,
                    UserId = userId,
                    Date = DateTime.UtcNow,
                };

                await this.context.UsersJobApplications.AddAsync(userApplication);
            }

            await this.context.JobApplications.AddAsync(application);
            await this.context.SaveChangesAsync();

            return application.Id.ToString();
        }

        public async Task<ICollection<AllJobApplicationViewModel>> AllCandidatesByCompanyIdAsync(Guid? companyId)
        {
            if (companyId is null)
            {
                return Array.Empty<AllJobApplicationViewModel>();
            }

            var jobOffersApplications = await this.context
                .JobOffers
                .AsNoTracking()
                .Where(j => j.CompanyId == companyId &&
                            j.JobApplications.Any())
                .Select(j => new AllJobApplicationViewModel()
                {
                    JobOfferId = j.Id.ToString(),
                    JobOfferTitle = j.JobPosition,
                    JobApplications = j.JobApplications
                        .Select(a => new JobApplicationViewModel()
                        {
                            Id = a.Id.ToString(),
                            CandidateName = a.CandidateName,
                            Email = a.Email,
                            Status = a.Status.ToString()
                        }).ToList(),
                })
                .ToListAsync();

            return jobOffersApplications;
        }

        public async Task<JobApplicationViewModel> GetApplicationById(Guid applicationId, Guid companyUserId)
        {
            ApplicationDetailsData application = await this.context.JobApplications
                .AsNoTracking()
                .Where(application =>
                    application.Id == applicationId &&
                    application.JobOffer.Company.CreatorId == companyUserId)
                .Select(ApplicationDetailsSelector)
                .FirstOrDefaultAsync()
                ?? throw new InvalidOperationException("Application does not exist or does not belong to the company.");

            return MapApplicationDetails(application);
        }

        public async Task<IEnumerable<MyApplicationViewModel>> AllUserApplicationsAsync(Guid userId)
        {
            var userApplications = await this.context
                .UsersJobApplications
                .AsNoTracking()
                .Where(a => a.UserId == userId)
                .Select(a => new MyApplicationViewModel()
                {
                    SavedDate = a.Date.ToString("dd.MM.yyyy"),
                    CompanyId = a.JobApplication.JobOffer.Company.Id.ToString(),
                    CompanyName = a.JobApplication.JobOffer.Company.Name,
                    JobOfferId = a.JobApplication.JobOfferId.ToString(),
                    JobTitle = a.JobApplication.JobOffer.JobPosition,
                    Status = a.JobApplication.Status.ToString()!
                })
                .ToListAsync();

            return userApplications;
        }

        public async Task<bool> ExistsByIdAsync(Guid id)
            => await this.context.JobApplications
                .AsNoTracking()
                .AnyAsync(application => application.Id == id);

        public async Task<bool> IsOwnedByCompanyAsync(Guid id, Guid companyUserId)
            => await this.context.JobApplications
                .AsNoTracking()
                .AnyAsync(application =>
                    application.Id == id &&
                    application.JobOffer.Company.CreatorId == companyUserId);

        public Task ApproveApplicationAsync(Guid id, Guid companyUserId)
            => UpdateApplicationStatusAsync(id, companyUserId, ApplicationStatus.Approved);

        public Task RejectApplicationAsync(Guid id, Guid companyUserId)
            => UpdateApplicationStatusAsync(id, companyUserId, ApplicationStatus.Rejected);

        private async Task UpdateApplicationStatusAsync(Guid id, Guid companyUserId, ApplicationStatus status)
        {
            var application = await this.context.JobApplications
                .FirstOrDefaultAsync(application =>
                    application.Id == id &&
                    application.JobOffer.Company.CreatorId == companyUserId)
                ?? throw new InvalidOperationException("Application does not exist or does not belong to the company.");

            if (application.Status != status)
            {
                application.Status = status;
                await this.context.SaveChangesAsync();
            }
        }

        private static string ExtractDocumentName(string url)
        {
            string[] parts = url.Split('/');

            string documentName = parts[parts.Length - 1];

            return documentName;
        }

        private static JobApplicationViewModel MapApplicationDetails(ApplicationDetailsData application)
        {
            const string googleDocsViewerBaseUrl = "https://docs.google.com/viewer?url=";

            return new JobApplicationViewModel
            {
                Id = application.Id.ToString(),
                CandidateName = application.CandidateName,
                Email = application.Email,
                MotivationalLetter = application.MotivationalLetter,
                JobPosition = application.JobPosition,
                DocumentsUrl = application.DocumentUrls
                    .Select(documentUrl => new DocumentViewModel
                    {
                        DocumentName = ExtractDocumentName(documentUrl),
                        DocumentUrl = $"{googleDocsViewerBaseUrl}{HttpUtility.UrlEncode(documentUrl)}",
                    })
                    .ToList(),
            };
        }

        private static readonly Expression<Func<JobApplication, ApplicationDetailsData>> ApplicationDetailsSelector =
            application => new ApplicationDetailsData
            {
                Id = application.Id,
                CandidateName = application.CandidateName,
                Email = application.Email,
                MotivationalLetter = application.MotivationalLetter,
                JobPosition = application.JobOffer.JobPosition,
                DocumentUrls = application.Documents
                    .Select(document => document.DocumentUrl)
                    .ToList(),
            };

        private sealed class ApplicationDetailsData
        {
            public Guid Id { get; init; }
            public string CandidateName { get; init; } = null!;
            public string Email { get; init; } = null!;
            public string MotivationalLetter { get; init; } = null!;
            public string JobPosition { get; init; } = null!;
            public List<string> DocumentUrls { get; init; } = new();
        }
    }
}
