namespace DevHunter.Data.Models.Enums
{
	using System.ComponentModel.DataAnnotations;

	public enum WorkExperience
	{
		[Display(Name = "Junior / Intern")]
		Junior,
		[Display(Name = "1-2 years work experience")]
		OneTwoYears,
		[Display(Name = "2-5 years work experience")]
		TwoFiveYears,
		[Display(Name = "5+ work experience")]
		FivePlusYears,
		[Display(Name = "Team Lead")]
		TeamLead
	}
}
