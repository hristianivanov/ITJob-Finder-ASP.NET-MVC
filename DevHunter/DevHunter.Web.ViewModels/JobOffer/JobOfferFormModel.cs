namespace DevHunter.Web.ViewModels.JobOffer
{
	public class JobOfferFormModel
	{
		public string Id { get; set; } = null!;
		public string Title { get; set; } = null!;
		public string? Location { get; set; }
		public bool IsRemote { get; set; }
		public string? WorkingExperience { get; set; }
		public int? Seniority { get; set; }
        public int? WorkingHours { get; set; }
        public decimal? Salary { get; set; }
		public string? Description { get; set; } = null!;
	}
}
