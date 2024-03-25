namespace DevHunter.Data.Models.Enums
{
	using System.ComponentModel.DataAnnotations;

	public enum Seniority
	{
		[Display(Name = "Junior / Intern")]
		Intern,
		[Display(Name = "1-2 years work experience")]
		Junior,
		[Display(Name = "2-5 years work experience")]
		Mid,
		[Display(Name = "5+ years work experience")]
		Senior,
		[Display(Name = "Team Lead")]
		GrandMaster
	}
}
