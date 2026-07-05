namespace DevHunter.Services.Data.Interfaces
{
    using Web.ViewModels.User;
    using Web.ViewModels.Company;

    public interface ICompanyService
    {
        Task AddAsync(CompanyRegisterFormModel model, Guid userId);
        Task<bool> ExistsByNameAsync(string name);
        Task<CompanyDetailViewModel> GetDetailsByIdAsync(Guid id);
        Task<bool> ExistsByIdAsync(Guid id);
        Task<bool> IsOwnedByUserAsync(Guid id, Guid userId);
        Task<CompanyFormModel> GetForEditByIdAsync(Guid id);
        Task EditAsync(Guid id, CompanyFormModel model, Guid userId);
        Task<Guid?> GetCompanyIdByCreatorIdAsync(Guid userId);
        Task<IEnumerable<CompanyAdminViewModel>> AllForAdminAsync();
        Task<IEnumerable<CompanyAllViewModel>> AllAsync();
    }
}
