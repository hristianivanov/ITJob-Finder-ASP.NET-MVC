namespace DevHunter.Web.ViewModels.JobOffer
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	using Data.Models.Enums;

	using static Common.EntityValidationConstants.JobOffer;

	public class JobOfferEditFormModel
	{
		public JobOfferEditFormModel()
		{
			this.LocationTypeModels = Enum.GetValues(typeof(PlaceToWork))
				.OfType<PlaceToWork>()
				.Select(e => new LocationTypeFormModel(e))
				.ToList();

			this.SalaryTypeModels = Enum.GetValues(typeof(SalaryType))
				.OfType<SalaryType>()
				.Select(e => new SalaryTypeFormModel(e))
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
		public decimal? MinSalary { get; set; }
		public decimal? MaxSalary { get; set; }

		[Display(Name = "Job salary")]
		public SalaryType? SalaryType { get; set; }

		[Required]
		public string Description { get; set; } = null!;
		public string? Technologies { get; set; }

		public ICollection<LocationTypeFormModel> LocationTypeModels { get; set; }
		public ICollection<SalaryTypeFormModel> SalaryTypeModels { get; set; }
	}

}
