namespace DevHunter.Web.ViewModels.JobOffer
{
	using System.ComponentModel.DataAnnotations;

	using Data.Models.Enums;

	using static Common.EntityValidationConstants.JobOffer;

	public class JobOfferFormModel
	{
		public JobOfferFormModel()
		{
			this.LocationTypeModels = Enum.GetValues(typeof(PlaceToWork))
				.OfType<PlaceToWork>()
				.Select(e => new LocationTypeFormModel(e))
				.ToList();
		}

		[Required]
		[StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
		public string Title { get; set; } = null!;

		public string? Location { get; set; }

		[Required]
		[Display(Name = "Job location")]
		public PlaceToWork? LocationType { get; set; }

		public string? WorkingExperience { get; set; }
		public int? WorkingHours { get; set; }
		public decimal? Salary { get; set; }

		[Required]
		public string Description { get; set; } = null!;

		public string? Technologies { get; set; }

		public ICollection<LocationTypeFormModel> LocationTypeModels { get; set; }
	}
	
}
