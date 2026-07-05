namespace DevHunter.Services.Data.Interfaces
{
    using Web.ViewModels.JobApplication;

    public interface IJobApplicationService
    {
        Task<string> ApplyJobOfferAsync(JobApplicationFormModel model, Guid jobOfferId, Guid userId);
        Task<ICollection<AllJobApplicationViewModel>> AllCandidatesByCompanyIdAsync(Guid? companyId);
        Task<JobApplicationViewModel> GetApplicationById(Guid applicationId, Guid companyUserId);
        Task<IEnumerable<MyApplicationViewModel>> AllUserApplicationsAsync(Guid userId);
        Task<bool> ExistsByIdAsync(Guid id);
        Task<bool> IsOwnedByCompanyAsync(Guid id, Guid companyUserId);
        Task ApproveApplicationAsync(Guid id, Guid companyUserId);
        Task RejectApplicationAsync(Guid id, Guid companyUserId);
    }
}
