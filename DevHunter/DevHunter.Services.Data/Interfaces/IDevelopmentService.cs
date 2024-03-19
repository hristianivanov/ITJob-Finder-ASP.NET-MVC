namespace DevHunter.Services.Data.Interfaces
{
	using Web.ViewModels.Development;

	public interface IDevelopmentService
	{
		Task<bool> ExistsByNameAsync(string name);
		Task AddAsync(DevelopmentFormModel formModel);
		Task<List<DevelopmentViewModel>> AllAsync();
		Task<bool> ExistsByIdAsync(string id);	
		Task<DevelopmentEditFormModel> GetForEditByIdAsync(string id);
	}
}
