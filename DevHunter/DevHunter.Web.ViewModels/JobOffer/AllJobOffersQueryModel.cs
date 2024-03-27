using Microsoft.AspNetCore.Mvc;

namespace DevHunter.Web.ViewModels.JobOffer
{
	using System.ComponentModel.DataAnnotations;

	public class AllJobOffersQueryModel
	{
		public AllJobOffersQueryModel()
		{
			this.CurrentPage = 1;
			this.JobOffersPerPage = 10;
			this.JobOffers = new HashSet<JobOfferAllViewModel>();
		}

		[FromQuery(Name = "job_location")]
		public string? JobLocation { get; set; }
		[FromQuery(Name = "seniority")]
		public string? Experience { get; set; }

		[FromQuery(Name = "search")]
        public string? SearchString { get; set; }

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
			this.Locations = new HashSet<LocationFilter>();
			this.Experiences = new HashSet<SeniorityFilter>();
		}

		public IEnumerable<SeniorityFilter> Experiences { get; set; }
		public IEnumerable<LocationFilter> Locations { get; set; }
	}

	public class SeniorityFilter
	{
		public string Seniority { get; set; } = null!;

		public int Count { get; set; }

		public bool IsChecked { get; set; }
	}


	public class LocationFilter
	{
		public string Location { get; set; } = null!;

		public int Count { get; set; }

		public bool IsChecked { get; set; }
	}
}
