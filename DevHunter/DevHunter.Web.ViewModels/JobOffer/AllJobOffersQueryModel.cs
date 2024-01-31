namespace DevHunter.Web.ViewModels.JobOffer
{
	public class AllJobOffersQueryModel
	{
		public AllJobOffersQueryModel()
		{
			//TODO: to general
			this.CurrentPage = 1;
			this.JobOffersPerPage = 10;
			this.JobOffers = new HashSet<JobOfferAllViewModel>();
		}

		//TODO: filtering and sorting properties
		public int CurrentPage { get; set; }
		public int TotalJobOffersCount { get; set; }
		public int JobOffersPerPage { get; set; }
		public IEnumerable<JobOfferAllViewModel> JobOffers { get; set; }
	}
}
