namespace DevHunter.Services.Data.Interfaces
{
	using Models.JobOffer;
	using Web.ViewModels.JobOffer;

	public interface IJobOfferService
	{
		Task<AllJobOffersFilteredAndPagedServiceModel> AllAsync(AllJobOffersQueryModel queryModel);
		Task AddAsync(JobOfferFormModel model, string userId);
		Task<string> CreateAndReturnIdAsync(JobOfferFormModel model,string userId);
		Task<bool> ExistsByIdAsync(string id);
		Task<JobOfferDetailsViewModel> GetDetailsByIdAsync(string id);
		Task<IEnumerable<JobOfferAllViewModel>> AllByCompanyIdAsync(string userId);
		Task<JobOfferEditFormModel> GetForEditByIdAsync(string id);
		Task DeleteByIdAsync(string id);
	}
}