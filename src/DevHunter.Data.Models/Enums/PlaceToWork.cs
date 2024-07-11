namespace DevHunter.Data.Models.Enums
{
	using System.ComponentModel.DataAnnotations;

	public enum PlaceToWork
	{
		[Display(Name = "In-person, precise location")]
		Location,
		[Display(Name = "Remote")]
		Remote,
		[Display(Name = "Hybrid remote")]
		Hybrid,
		[Display(Name = "On the road")]
		Road
	}
}
