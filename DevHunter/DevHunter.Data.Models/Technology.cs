namespace DevHunter.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Technology
	{
		public Technology()
		{
			this.Id = Guid.NewGuid();
		}

		[Key]
		public Guid Id { get; set; }

		public string Name { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;

		[ForeignKey(nameof(JobOffer))]
		public Guid JobOfferId { get; set; }

		public JobOffer JobOffer { get; set; } = null!;

		[ForeignKey(nameof(Company))]
		public Guid CompanyId { get; set; }

		public Company Company { get; set; } = null!;

		[ForeignKey(nameof(Development))]
		public Guid DevelopmentId { get; set; }

		public Development Development { get; set; }
	}
}