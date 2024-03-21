namespace DevHunter.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class ApplicationDocument
	{
		public ApplicationDocument()
		{
			this.Id = Guid.NewGuid();
		}

		[Key]
		public Guid Id { get; set; }

		[Required]
		public string DocumentUrl { get; set; } = null!;

		[ForeignKey(nameof(JobApplication))]
        public Guid JobApplicationId { get; set; }

        public virtual JobApplication JobApplication { get; set; } = null!;
	}
}
