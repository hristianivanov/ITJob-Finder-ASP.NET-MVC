using DevHunter.Web.ViewModels.Technology;

namespace DevHunter.Services.Data.Interfaces
{
	public interface ITechnologyService
	{
		Task<bool> TechnologyExistsByNameAsync(string technologyName);
		Task AddAsync(TechnologyFormModel formModel);
	}
}
