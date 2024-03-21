namespace DevHunter.Services.Data
{
	using DevHunter.Data;
	using DevHunter.Data.Models;

	using Interfaces;
	using Microsoft.EntityFrameworkCore;
	using Web.ViewModels.JobApplication;

	public class JobApplicationService : IJobApplicationService
	{
		private readonly DevHunterDbContext context;

		public JobApplicationService(DevHunterDbContext context)
		{
			this.context = context;
		}

		public async Task<string> ApplyJobOfferAsync(JobApplicationFormModel model, string jobOfferId)
		{
			var application = new JobApplication()
			{
				Email = model.Email,
				CandidateName = model.CandidateName,
				MotivationalLetter = model.MotivationalLetter,
				JobOfferId = Guid.Parse(jobOfferId)
			};

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
					DocumentUrl = d.DocumentUrl,
				}).ToList(),
			};
		}

		private static string ExtractDocumentName(string url)
		{
			string[] parts = url.Split('/');
		
			string documentName = parts[parts.Length - 1];
		
			return documentName;
		}
	}
}
