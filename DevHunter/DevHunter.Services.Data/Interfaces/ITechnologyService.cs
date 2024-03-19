namespace DevHunter.Services.Data.Interfaces
{
	using Web.ViewModels.Technology;

	public interface ITechnologyService
	{
		Task<bool> TechnologyExistsByNameAsync(string technologyName);
		Task AddAsync(TechnologyFormModel formModel);
		Task<IEnumerable<TechnologyViewModel>> AllAsync();
		Task<bool> ExistsByIdAsync(string id);
		Task<TechnologyEditFormModel> GetForEditByIdAsync(string id);
		Task EditTechnologyAsync(string technologyId, TechnologyEditFormModel model);
		Task DeleteByIdAsync(string id);

		//Task<Stream> GetThumbnail(string id);
		//Task<Stream> GetOriginal(string id);
		Task<IEnumerable<TechnologyViewModel>> AllByDevelopmentAsync(string id);
	}
}
