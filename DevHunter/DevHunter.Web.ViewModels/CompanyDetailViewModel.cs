namespace DevHunter.Web.ViewModels
{
	using JobOffer;

	public class CompanyDetailViewModel
	{
        public CompanyDetailViewModel()
        {
            this.JobOffers = new HashSet<JobOfferAllViewModel>();
        }

        public string Id { get; set; } = null!;

		public string Name { get; set; } = null!;

		public string Description { get; set; } = null!;

        public string Activity { get; set; } = null!;

        public string Sector { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string WebsiteUrl { get; set; } = null!;

        public int FoundedYear { get; set; }

        //public string AdditionalInfo { get; set; } = null!;

        public int EmployeesCnt { get; set; }

        public int PaidVacationDays { get; set; }

        public ICollection<JobOfferAllViewModel> JobOffers { get; set; }
    }
}
