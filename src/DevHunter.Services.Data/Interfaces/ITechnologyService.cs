namespace DevHunter.Services.Data.Interfaces
{
    using Web.ViewModels.Technology;

    public interface ITechnologyService
    {
        Task<bool> TechnologyExistsByNameAsync(string technologyName);
        Task AddAsync(TechnologyFormModel formModel, Guid? developmentId);
        Task<IEnumerable<TechnologyViewModel>> AllAsync();
        Task<bool> ExistsByIdAsync(Guid id);
        Task<TechnologyEditFormModel> GetForEditByIdAsync(Guid id);
        Task EditTechnologyAsync(Guid technologyId, TechnologyEditFormModel model);
        Task DeleteByIdAsync(Guid id);

        //Task<Stream> GetThumbnail(string id);
        //Task<Stream> GetOriginal(string id);
        Task<IEnumerable<TechnologyViewModel>> AllByDevelopmentAsync(Guid id);
        Task<IEnumerable<TechnologyViewModel>> AllByJobOfferIdAsync(Guid id);
        Task<IEnumerable<TechnologyViewModel>> AllWithoutJobOfferOnesAsync(Guid id);
    }
}
