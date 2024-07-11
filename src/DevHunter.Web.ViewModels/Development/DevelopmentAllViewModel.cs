namespace DevHunter.Web.ViewModels.Development
{
	public class DevelopmentAllViewModel
	{
		public DevelopmentAllViewModel()
		{
			this.Developments = new HashSet<DevelopmentViewModel>();
		}

        public ICollection<DevelopmentViewModel> Developments { get; set; }
	}
}
