namespace DevHunter.Services.Data.Interfaces
{
    using Web.ViewModels.Development;

    public interface IDevelopmentService
    {
        Task<bool> ExistsByNameAsync(string name);
        Task AddAsync(DevelopmentFormModel formModel);
        Task<List<DevelopmentViewModel>> AllAsync();
        Task<bool> ExistsByIdAsync(Guid id);
        Task<DevelopmentEditFormModel> GetForEditByIdAsync(Guid id);
        Task EditDevelopmentAsync(Guid id, DevelopmentEditFormModel model);
        Task DeleteByIdAsync(Guid id);
        Task<DevelopmentOfferViewModel> GetByIdAsync(Guid id);
    }
}
