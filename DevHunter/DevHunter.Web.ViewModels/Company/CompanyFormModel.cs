namespace DevHunter.Web.ViewModels.Company
{
	public class CompanyFormModel
	{
		public string Name { get; set; } = null!;

		public string? ImageUrl { get; set; }

		public string? Description { get; set; }

		public string? Activity { get; set; }

		public string? Sector { get; set; }

        public string? Address { get; set; } 

		public DateTime? FoundedDate { get; set; }

		public int? EmployeesCnt { get; set; }

		public string? WebsiteUrl { get; set; }
	}
}
