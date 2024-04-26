namespace DevHunter.Services.Data.Interfaces
{
    using Web.ViewModels.User;
    using Web.ViewModels.Company;

    public interface ICompanyService
	{
		Task AddAsync(CompanyRegisterFormModel model, Guid userId);
		Task<bool> ExistsByNameAsync(string name);
		Task<CompanyDetailViewModel> GetDetailsByIdAsync(string id);
		Task<bool> ExistsByIdAsync(string id);
		Task<CompanyFormModel> GetForEditByIdAsync(string id);
		Task EditAsync(string id, CompanyFormModel model);
		Task<string?> GetCompanyIdByCreatorIdAsync(string userId);
		Task<IEnumerable<CompanyAdminViewModel>> AllForAdminAsync();
		Task<IEnumerable<CompanyAllViewModel>> AllAsync();
	}
}
