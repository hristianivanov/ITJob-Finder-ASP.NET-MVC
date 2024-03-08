namespace DevHunter.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	using Microsoft.EntityFrameworkCore;

	public class JobOffer
	{
		public JobOffer()
		{
			this.Id = Guid.NewGuid();
			this.TechnologyJobOffers = new HashSet<TechnologyJobOffers>();
			this.SavedJobOffers = new HashSet<SavedJobOffer>();
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
		public string Description { get; set; }

		public DateTime CreatedOn { get; set; }

		[ForeignKey(nameof(Company))]
		public Guid CompanyId { get; set; }

		public Company Company { get; set; } = null!;

		public string PlaceToWork { get; set; } = null!;

        public int WorkingHours { get; set; }

        public int Seniority { get; set; }

        public string? WorkingExperience { get; set; }

        public ICollection<TechnologyJobOffers> TechnologyJobOffers { get; set; }
		public ICollection<SavedJobOffer> SavedJobOffers { get; set; }
	}
}