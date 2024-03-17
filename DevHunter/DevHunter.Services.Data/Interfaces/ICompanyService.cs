namespace DevHunter.Services.Data.Interfaces
{
	using Web.ViewModels;
	using Web.ViewModels.User;

	public interface ICompanyService
	{
		Task AddAsync(CompanyRegisterFormModel model, Guid userId);
		Task<bool> ExistsByNameAsync(string name);
		Task<CompanyDetailViewModel> GetDetailsByIdAsync(string id);
		Task<bool> ExistsByIdAsync(string id);
	}
}
