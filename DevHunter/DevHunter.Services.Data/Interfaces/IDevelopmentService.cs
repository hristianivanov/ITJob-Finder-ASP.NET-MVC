namespace DevHunter.Services.Data.Interfaces
{
	using Web.ViewModels.Development;

	public interface IDevelopmentService
	{
		Task<bool> ExistsByNameAsync(string name);
		Task AddAsync(DevelopmentFormModel formModel);
	}
}
