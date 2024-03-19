using DevHunter.Web.ViewModels.Company;

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


        public string Description { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        public string JobLocation { get; set; } = null!;
		public CompanyViewModel Company { get; set; }

        public ICollection<TechnologyViewModel> TechStack { get; set; }
    }
}
