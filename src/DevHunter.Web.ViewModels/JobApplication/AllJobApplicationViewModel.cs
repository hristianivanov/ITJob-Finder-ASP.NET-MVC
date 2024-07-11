namespace DevHunter.Web.ViewModels.JobApplication
{
	public class AllJobApplicationViewModel
	{
		public AllJobApplicationViewModel()
		{
			this.JobApplications = new HashSet<JobApplicationViewModel>();
		}
		public string JobOfferTitle { get; set; } = null!;
		public string JobOfferId { get; set; } = null!;

		public ICollection<JobApplicationViewModel> JobApplications { get; set; }
	}
}
