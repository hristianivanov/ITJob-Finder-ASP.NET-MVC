using DevHunter.Services.Data.Models.JobOffer;
using DevHunter.Web.ViewModels.JobOffer;

namespace DevHunter.Services.Data.Interfaces
{
	public interface IJobOfferService
	{
		Task<AllJobOffersFilteredAndPagedServiceModel> AllAsync(AllJobOffersQueryModel queryModel);
	}
}