namespace DevHunter.Web.ViewModels.JobOffer
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	using Technology;

	using static Common.EntityValidationConstants.JobOffer;

	public class JobOfferEditFormModel
	{
		public JobOfferEditFormModel()
		{
			this.Technologies = new HashSet<TechnologyViewModel>();
			this.JobOfferTechnologies = new HashSet<TechnologyViewModel>();
		}

		[Required]
		[StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
		public string Title { get; set; } = null!;

		public string? Location { get; set; }
		public bool IsRemote { get; set; }
		public string? WorkingExperience { get; set; }
		public int? Seniority { get; set; }
		public int? WorkingHours { get; set; }
		public decimal? Salary { get; set; }

		[Required]
		public string Description { get; set; } = null!;
		public string SelectedTechnologies { get; set; }
        public IEnumerable<TechnologyViewModel> JobOfferTechnologies { get; set; }
		public IEnumerable<TechnologyViewModel> Technologies { get; set; }
	}

}
