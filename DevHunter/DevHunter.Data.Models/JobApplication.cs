namespace DevHunter.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class JobApplication
	{
		public JobApplication()
		{
			this.Id = Guid.NewGuid();
			this.Documents = new HashSet<ApplicationDocument>();
		}

		[Key]
		public Guid Id { get; set; }

		[Required]
		public string CandidateName { get; set; } = null!;

		[ForeignKey(nameof(JobOffer))]
        public Guid JobOfferId { get; set; }
		
		public virtual JobOffer JobOffer { get; set; } = null!;

		[Required]
		public string Email { get; set; } = null!;

		[Required] 
		public string MotivationalLetter { get; set; } = null!;

        public virtual ICollection<ApplicationDocument> Documents { get; set; }
    }
}
