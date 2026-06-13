namespace DevHunter.Services.Data
{
    using System.Linq.Expressions;
    using System.Web;

    using Microsoft.EntityFrameworkCore;

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

        public async Task<string> ApplyJobOfferAsync(JobApplicationFormModel model, string jobOfferId, string? userId)
        {
            ArgumentNullException.ThrowIfNull(model);

            if (!Guid.TryParse(jobOfferId, out Guid parsedJobOfferId))
            {
                throw new InvalidOperationException("A valid job offer id is required.");
            }

            bool jobOfferExists = await this.context.JobOffers
                .AsNoTracking()
                .AnyAsync(jobOffer => jobOffer.Id == parsedJobOfferId);

            if (!jobOfferExists)
            {
                throw new InvalidOperationException("Job offer does not exist.");
            }

            Guid? parsedUserId = null;
            if (!string.IsNullOrWhiteSpace(userId))
            {
                if (!Guid.TryParse(userId, out Guid validUserId))
                {
                    throw new InvalidOperationException("A valid user id is required.");
                }

                parsedUserId = validUserId;
            }

            var application = new JobApplication
            {
                Email = model.Email,
                CandidateName = model.CandidateName,
                MotivationalLetter = model.MotivationalLetter,
                JobOfferId = parsedJobOfferId
            };

            if (parsedUserId.HasValue)
            {
                var userApplication = new UserJobApplications
                {
                    JobApplicationId = application.Id,
                    UserId = parsedUserId.Value,
                    Date = DateTime.UtcNow,
                };

                await this.context.UsersJobApplications.AddAsync(userApplication);
            }

            await this.context.JobApplications.AddAsync(application);
            await this.context.SaveChangesAsync();

            return application.Id.ToString();
        }

        public async Task<ICollection<AllJobApplicationViewModel>> AllCandidatesByCompanyIdAsync(string? companyId)
        {
            if (!Guid.TryParse(companyId, out Guid parsedCompanyId))
            {
                return Array.Empty<AllJobApplicationViewModel>();
            }

            var jobOffersApplications = await this.context
                .JobOffers
                .AsNoTracking()
                .Where(j => j.CompanyId == parsedCompanyId &&
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

        public async Task<JobApplicationViewModel> GetApplicationById(string applicationId, string companyUserId)
        {
            (Guid parsedApplicationId, Guid parsedCompanyUserId) = ParseRequiredIds(applicationId, companyUserId);

            ApplicationDetailsData application = await this.context.JobApplications
                .AsNoTracking()
                .Where(application =>
                    application.Id == parsedApplicationId &&
                    application.JobOffer.Company.CreatorId == parsedCompanyUserId)
                .Select(ApplicationDetailsSelector)
                .FirstOrDefaultAsync()
                ?? throw new InvalidOperationException("Application does not exist or does not belong to the company.");

            return MapApplicationDetails(application);
        }

        public async Task<IEnumerable<MyApplicationViewModel>> AllUserApplicationsAsync(string userId)
        {
            if (!Guid.TryParse(userId, out Guid parsedUserId))
            {
                return Array.Empty<MyApplicationViewModel>();
            }

            var userApplications = await this.context
                .UsersJobApplications
                .AsNoTracking()
                .Where(a => a.UserId == parsedUserId)
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

        public async Task<bool> ExistsByIdAsync(string id)
        {
            if (!Guid.TryParse(id, out Guid applicationId))
            {
                return false;
            }

            return await this.context.JobApplications
                .AsNoTracking()
                .AnyAsync(application => application.Id == applicationId);
        }

        public async Task<bool> IsOwnedByCompanyAsync(string id, string companyUserId)
        {
            if (!TryParseIds(id, companyUserId, out Guid applicationId, out Guid parsedCompanyUserId))
            {
                return false;
            }

            return await this.context.JobApplications
                .AsNoTracking()
                .AnyAsync(application =>
                    application.Id == applicationId &&
                    application.JobOffer.Company.CreatorId == parsedCompanyUserId);
        }

        public Task ApproveApplicationAsync(string id, string companyUserId)
        {
            return UpdateApplicationStatusAsync(id, companyUserId, ApplicationStatus.Approved);
        }

        public Task RejectApplicationAsync(string id, string companyUserId)
        {
            return UpdateApplicationStatusAsync(id, companyUserId, ApplicationStatus.Rejected);
        }

        private async Task UpdateApplicationStatusAsync(string id, string companyUserId, ApplicationStatus status)
        {
            (Guid applicationId, Guid parsedCompanyUserId) = ParseRequiredIds(id, companyUserId);

            var application = await this.context.JobApplications
                .FirstOrDefaultAsync(application =>
                    application.Id == applicationId &&
                    application.JobOffer.Company.CreatorId == parsedCompanyUserId)
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

        private static (Guid FirstId, Guid SecondId) ParseRequiredIds(string firstId, string secondId)
        {
            if (!TryParseIds(firstId, secondId, out Guid parsedFirstId, out Guid parsedSecondId))
            {
                throw new InvalidOperationException("Valid identifiers are required.");
            }

            return (parsedFirstId, parsedSecondId);
        }

        private static bool TryParseIds(string firstId, string secondId, out Guid parsedFirstId, out Guid parsedSecondId)
        {
            bool firstIdIsValid = Guid.TryParse(firstId, out parsedFirstId);
            bool secondIdIsValid = Guid.TryParse(secondId, out parsedSecondId);

            return firstIdIsValid && secondIdIsValid;
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
