namespace DevHunter.Web.ViewModels.Company
{
	public class CompanyAllViewModel
	{
		public string Id { get; set; } = null!;

		public string Name { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;

		public int JobOffersCount { get; set; }

		public int EmployeesCount { get; set; }
	}
}
