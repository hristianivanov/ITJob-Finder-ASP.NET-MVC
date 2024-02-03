namespace DevHunter.Data.Models
{
	using System.ComponentModel.DataAnnotations.Schema;

	public class TechnologyJobOffers
	{
        [ForeignKey(nameof(JobOffer))]
        public Guid JobOfferId { get; set; }

        public JobOffer JobOffer { get; set; } = null!;

        [ForeignKey(nameof(Technology))]
        public Guid TechnologyId { get; set; }
        public Technology Technology { get; set; } = null!;
	}
}
