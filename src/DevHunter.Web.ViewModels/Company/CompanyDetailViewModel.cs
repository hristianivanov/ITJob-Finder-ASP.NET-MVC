namespace DevHunter.Web.ViewModels.Company
{
	using Technology;
	using JobOffer;

    public class CompanyDetailViewModel
    {
        public CompanyDetailViewModel()
        {
            JobOffers = new HashSet<JobOfferAllViewModel>();
            Technologies = new HashSet<TechnologyViewModel>();
        }

        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string? Description { get; set; }

        public string? Activity { get; set; }

        public string? Sector { get; set; }

        public string? Location { get; set; }

        public string? WebsiteUrl { get; set; }

        public int? FoundedYear { get; set; }

        public int? EmployeesCnt { get; set; }

        public IEnumerable<JobOfferAllViewModel> JobOffers { get; set; }
        public IEnumerable<TechnologyViewModel> Technologies { get; set; }
    }
}
