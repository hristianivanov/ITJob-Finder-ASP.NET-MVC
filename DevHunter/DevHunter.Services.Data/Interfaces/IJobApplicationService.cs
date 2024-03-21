namespace DevHunter.Services.Data.Interfaces
{
	using Web.ViewModels.JobApplication;

	public interface IJobApplicationService
	{
		Task<string> ApplyJobOfferAsync(JobApplicationFormModel model, string jobOfferId);
		Task<ICollection<AllJobApplicationViewModel>> AllCandidatesByCompanyIdAsync(string? companyId);
		Task<JobApplicationViewModel> GetApplicationById(string applicationId);
	}
}
