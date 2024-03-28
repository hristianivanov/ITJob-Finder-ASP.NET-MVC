namespace DevHunter.Services.Data
{
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
			var application = new JobApplication()
			{
				Email = model.Email,
				CandidateName = model.CandidateName,
				MotivationalLetter = model.MotivationalLetter,
				JobOfferId = Guid.Parse(jobOfferId)
			};

			if (!string.IsNullOrWhiteSpace(userId))
			{
				var userApplication = new UserJobApplications()
				{
					JobApplicationId = application.Id,
					UserId = Guid.Parse(userId),
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
			var jobOffersApplications = await this.context
				.JobOffers
				.Where(j => j.CompanyId.ToString() == companyId &&
							j.JobApplications.Count() != 0)
				.AsNoTracking()
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

		public async Task<JobApplicationViewModel> GetApplicationById(string applicationId)
		{
			var application = await this.context
				.JobApplications
				.FirstAsync(a => a.Id.ToString() == applicationId);

			string googleDocsViewerBaseUrl = "https://docs.google.com/viewer?url=";

			return new JobApplicationViewModel()
			{
				Id = application.Id.ToString(),
				CandidateName = application.CandidateName,
				Email = application.Email,
				MotivationalLetter = application.MotivationalLetter,
				JobPosition = application.JobOffer.JobPosition,
				DocumentsUrl = application.Documents.Select(d => new DocumentViewModel()
				{
					DocumentName = ExtractDocumentName(d.DocumentUrl),
					DocumentUrl = $"{googleDocsViewerBaseUrl}{HttpUtility.UrlEncode(d.DocumentUrl)}",
				}).ToList(),
			};
		}

		public async Task<IEnumerable<MyApplicationViewModel>> AllUserApplicationsAsync(string userId)
		{
			var userApplications = await this.context
				.UsersJobApplications
				.Where(a => a.UserId.ToString() == userId)
				.Select(a => new MyApplicationViewModel()
				{
					SavedDate = a.Date.ToString("dd.MM.yyyy"),
					CompanyName = a.JobApplication.JobOffer.Company.Name,
					JobTitle = a.JobApplication.JobOffer.JobPosition,
					Status = a.JobApplication.Status.ToString()!
				})
				.ToListAsync();

			return userApplications;
		}

		public async Task<bool> ExistsByIdAsync(string id)
		{
			var result = await this.context
				.JobApplications
				.FirstOrDefaultAsync(a => a.Id.ToString() == id);

			return result != null!;
		}

		public async Task ApproveApplicationAsync(string id)
		{
			var application = await this.context
				.JobApplications
				.FirstAsync(a => a.Id.ToString() == id);

			application!.Status = ApplicationStatus.Approved;

			await this.context.SaveChangesAsync();
		}

		public async Task RejectApplicationAsync(string id)
		{
			var application = await this.context
				.JobApplications
				.FirstAsync(a => a.Id.ToString() == id);

			application!.Status = ApplicationStatus.Rejected;

			await this.context.SaveChangesAsync();
		}

		private static string ExtractDocumentName(string url)
		{
			string[] parts = url.Split('/');

			string documentName = parts[parts.Length - 1];

			return documentName;
		}
	}
}
