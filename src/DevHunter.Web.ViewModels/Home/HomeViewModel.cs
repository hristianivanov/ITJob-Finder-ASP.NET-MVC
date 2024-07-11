namespace DevHunter.Web.ViewModels.Home
{
	using Development;

	public class HomeViewModel
	{
        public HomeViewModel()
        {
	        this.Developments = new HashSet<DevelopmentViewModel>();
        }
        public ICollection<DevelopmentViewModel> Developments { get; set; }
    }
}
