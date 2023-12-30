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
            this.Technologies = new HashSet<Technology>();
            this.SavedJobOffers = new HashSet<SavedJobOffer>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string JobPosition { get; set; } = null!;

        [Precision(18,2)]
        public decimal? Salary { get; set; }

        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }

        public Company Company { get; set; } = null!;

        public string PlaceToWork { get; set; } = null!;

        public int Seniority { get; set; }

        public ICollection<Technology> Technologies { get; set; }
        public ICollection<SavedJobOffer> SavedJobOffers { get; set; }
    }

}