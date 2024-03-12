namespace DevHunter.Web.ViewModels.JobOffer
{
	using DevHunter.Web.ViewModels.Technology;

	public class JobOfferDetailsViewModel
	{
        public JobOfferDetailsViewModel()
        {
            this.TechStack = new HashSet<TechnologyViewModel>();
        }

        public string Id { get; set; } = null!;

		public string Title { get; set; } = null!;

        public string CompanyImageUrl { get; set; } = null!;

        public string Description { get; set; } = null!;

        public ICollection<TechnologyViewModel> TechStack { get; set; }
    }
}
