namespace DevHunter.Web.ViewModels.JobApplication
{
	public class MyApplicationViewModel
	{
		public string JobOfferId { get; set; } = null!;
		public string JobTitle { get; set; } = null!;

		public string SavedDate { get; set; } = null!;

        public string CompanyId { get; set; } = null!;
        public string CompanyName { get; set; } = null!;

        public string Status { get; set; } = null!;
	}
}
