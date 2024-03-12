namespace DevHunter.Services.Data.Interfaces
{
	using Web.ViewModels.User;

	public interface ICompanyService
	{
		Task AddAsync(CompanyRegisterFormModel model, Guid userId);
		Task<bool> ExistsByNameAsync(string name);
	}
}
