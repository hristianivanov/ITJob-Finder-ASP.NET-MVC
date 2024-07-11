namespace DevHunter.Services.Data.Models.JobOffer
{
	using DevHunter.Web.ViewModels.JobOffer;

	public class AllJobOffersFilteredAndPagedServiceModel
	{
		public AllJobOffersFilteredAndPagedServiceModel()
		{
			this.JobOffers = new HashSet<JobOfferAllViewModel>();
		}

		public int TotalJobOffersCount { get; set; }

		public IEnumerable<JobOfferAllViewModel> JobOffers { get; set; }
	}
}
