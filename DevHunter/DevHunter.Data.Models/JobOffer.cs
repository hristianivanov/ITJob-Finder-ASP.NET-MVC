namespace DevHunter.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	using Microsoft.EntityFrameworkCore;

	using static Common.EntityValidationConstants.JobOffer;

	public class JobOffer
	{
		public JobOffer()
		{
			this.Id = Guid.NewGuid();
			this.JobOfferTechnologies = new HashSet<TechnologyJobOffers>();
			this.SavedJobOffers = new HashSet<SavedJobOffer>();
			this.JobApplications = new HashSet<JobApplication>();
		}

		[Key]
		public Guid Id { get; set; }

        public string JobPosition { get; set; } = null!;

		[Precision(18,2)]
		public decimal? MinSalary { get; set; }

		[Precision(18, 2)]
		public decimal? MaxSalary { get; set; }

		[Required]
		[MaxLength(int.MaxValue)] 
		public string Description { get; set; } = null!;

		public DateTime CreatedOn { get; set; }

		[ForeignKey(nameof(Company))]
		public Guid CompanyId { get; set; }

		public virtual Company Company { get; set; } = null!;

		public string PlaceToWork { get; set; } = null!;

        public int WorkingHours { get; set; }

        public string? WorkingExperience { get; set; }

        public virtual ICollection<TechnologyJobOffers> JobOfferTechnologies { get; set; }
		public virtual ICollection<SavedJobOffer> SavedJobOffers { get; set; }
		public virtual ICollection<JobApplication> JobApplications { get; set; }
	}
}