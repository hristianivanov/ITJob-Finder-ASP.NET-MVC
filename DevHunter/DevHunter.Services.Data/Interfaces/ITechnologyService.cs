using DevHunter.Web.ViewModels.Technology;

namespace DevHunter.Services.Data.Interfaces
{
	public interface ITechnologyService
	{
		Task<bool> TechnologyExistsByNameAsync(string technologyName);
		Task AddAsync(TechnologyFormModel formModel);
		Task<IEnumerable<TechnologyViewModel>> AllAsync();

		//Task<Stream> GetThumbnail(string id);
		//Task<Stream> GetOriginal(string id);
	}
}
