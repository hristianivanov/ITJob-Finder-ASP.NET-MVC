namespace DevHunter.Web.ViewModels.Development
{
	using DevHunter.Web.ViewModels.Technology;

	public class DevelopmentViewModel
	{
        public DevelopmentViewModel()
        {
            this.Technologies = new HashSet<TechnologyViewModel>();
        }

        public string Id { get; set; } = null!;

		public string Name { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;

        public IEnumerable<TechnologyViewModel> Technologies { get; set; }
	}
}
