namespace DevHunter.Web.ViewModels.JobOffer
{
	public class AllJobOffersQueryModel
	{
		public AllJobOffersQueryModel()
		{
			this.CurrentPage = 1;
			this.JobOffersPerPage = 10;
			this.JobOffers = new HashSet<JobOfferAllViewModel>();
		}
		public int CurrentPage { get; set; }
		public int TotalJobOffersCount { get; set; }
		public int JobOffersPerPage { get; set; }
		public AllFilterViewModel Filters { get; set; }
		public IEnumerable<JobOfferAllViewModel> JobOffers { get; set; }
	}

	public class AllFilterViewModel
	{
		public AllFilterViewModel()
		{
			this.FilterLocations = new HashSet<LocationFilter>();
			this.FilterExperiences = new HashSet<SeniorityFilter>();
		}

		public IEnumerable<SeniorityFilter> FilterExperiences { get; set; }
		public IEnumerable<LocationFilter> FilterLocations { get; set; }
	}

	public class SeniorityFilter
	{
		public string Seniority { get; set; } = null!;

		public int Count { get; set; }
	}


	public class LocationFilter
	{
		public string Location { get; set; } = null!;

		public int Count { get; set; }
	}
}
