namespace DevHunter.Services.Data.Interfaces
{
	using Web.ViewModels.JobApplication;

	public interface IJobApplicationService
	{
		Task<string> ApplyJobOfferAsync(JobApplicationFormModel model, string jobOfferId,string? userId);
		Task<ICollection<AllJobApplicationViewModel>> AllCandidatesByCompanyIdAsync(string? companyId);
		Task<JobApplicationViewModel> GetApplicationById(string applicationId);
		Task<IEnumerable<MyApplicationViewModel>> AllUserApplicationsAsync(string userId);
		Task<bool> ExistsByIdAsync(string id);
		Task ApproveApplicationAsync(string id);
		Task RejectApplicationAsync(string id);
	}
}
