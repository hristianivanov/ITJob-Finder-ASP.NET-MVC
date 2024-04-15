namespace DevHunter.Data.Models.Enums
{
	using System.ComponentModel.DataAnnotations;

	public enum SalaryType
	{
		[Display(Name = "Range")]
		Range,
		[Display(Name = "Starting amount")]
		Start,
		[Display(Name = "Maximum amount")]
		Max,
		[Display(Name = "Exact amount")]
		Exact,
	}
}
