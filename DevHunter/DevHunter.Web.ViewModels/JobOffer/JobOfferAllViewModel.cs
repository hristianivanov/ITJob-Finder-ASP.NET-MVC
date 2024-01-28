namespace DevHunter.Web.ViewModels.JobOffer
{
	using Technology;

	public class JobOfferAllViewModel
	{
		public JobOfferAllViewModel()
		{
			this.Technologies = new HashSet<TechnologyViewModel>();
		}

		public string Id { get; set; } = null!;
		public string JobPosition { get; set; } = null!;
		public string JobLocation { get; set; } = null!;
		public string MinSalary { get; set; } = null!;
        public string MaxSalary { get; set; } = null!;
		public string CompanyImageUrl { get; set; } = null!;
		public string CompanyName { get; set; } = null!;
        public string CreatedOn { get; set; } = null!;

        IEnumerable<TechnologyViewModel> Technologies { get; set; }
	}
}
