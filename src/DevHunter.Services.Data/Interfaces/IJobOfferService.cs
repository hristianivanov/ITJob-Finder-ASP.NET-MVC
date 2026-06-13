namespace DevHunter.Services.Data.Interfaces
{
    using Models.JobOffer;
    using Web.ViewModels.JobOffer;

    public interface IJobOfferService
    {
        Task<AllJobOffersFilteredAndPagedServiceModel> AllAsync(AllJobOffersQueryModel queryModel);
        Task<string> CreateAndReturnIdAsync(JobOfferFormModel model, string userId);
        Task<bool> ExistsByIdAsync(string id);
        Task<bool> IsOwnedByCompanyAsync(string id, string userId);
        Task<JobOfferDetailsViewModel> GetDetailsByIdAsync(string id);
        Task<IEnumerable<JobOfferAllViewModel>> AllByCompanyIdAsync(string userId);
        Task<JobOfferEditFormModel> GetForEditByIdAsync(string id);
        Task DeleteByIdAsync(string id, string userId);
        Task<AllFilterViewModel> LoadFiltersAsync();
        Task EditJobOfferAsync(string id, JobOfferEditFormModel model, string userId);
        Task<AllJobOffersFilteredAndPagedServiceModel> AllBySearchAsync(AllJobOffersQueryModel queryModel);
        Task SaveJobAsync(string jobOfferId, string userId);
        Task<bool> IsJobOfferSaved(string jobOfferId, string userId);
        Task RemoveSaveJobAsync(string jobOfferId, string userId);
        Task<IEnumerable<JobOfferSavedViewModel>> AllSavedJobOffersByUserIdAsync(string userId);
    }
}
