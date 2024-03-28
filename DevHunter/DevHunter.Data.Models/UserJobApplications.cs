namespace DevHunter.Data.Models
{
	using System.ComponentModel.DataAnnotations.Schema;

	public class UserJobApplications
	{
		[ForeignKey(nameof(User))]
		public Guid UserId { get; set; }
		public virtual ApplicationUser User { get; set; } = null!;

		[ForeignKey(nameof(JobApplication))]
		public Guid JobApplicationId { get; set; }
		public virtual JobApplication JobApplication { get; set; } = null!;

		public DateTime Date { get; set; }
	}
}
