namespace DevHunter.Services.Data.Interfaces
{
    using Models.JobOffer;
    using Web.ViewModels.JobOffer;

    public interface IJobOfferService
    {
        Task<AllJobOffersFilteredAndPagedServiceModel> AllAsync(AllJobOffersQueryModel queryModel);
        Task<string> CreateAndReturnIdAsync(JobOfferFormModel model, Guid userId);
        Task<bool> ExistsByIdAsync(Guid id);
        Task<bool> IsOwnedByCompanyAsync(Guid id, Guid userId);
        Task<JobOfferDetailsViewModel> GetDetailsByIdAsync(Guid id);
        Task<IEnumerable<JobOfferAllViewModel>> AllByCompanyIdAsync(Guid userId);
        Task<JobOfferEditFormModel> GetForEditByIdAsync(Guid id);
        Task DeleteByIdAsync(Guid id, Guid userId);
        Task<AllFilterViewModel> LoadFiltersAsync();
        Task EditJobOfferAsync(Guid id, JobOfferEditFormModel model, Guid userId);
        Task<AllJobOffersFilteredAndPagedServiceModel> AllBySearchAsync(AllJobOffersQueryModel queryModel);
        Task SaveJobAsync(Guid jobOfferId, Guid userId);
        Task<bool> IsJobOfferSaved(Guid jobOfferId, Guid userId);
        Task RemoveSaveJobAsync(Guid jobOfferId, Guid userId);
        Task<IEnumerable<JobOfferSavedViewModel>> AllSavedJobOffersByUserIdAsync(Guid userId);
    }
}
