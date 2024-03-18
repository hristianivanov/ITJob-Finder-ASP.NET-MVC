namespace DevHunter.Data.Models
{
	using System.ComponentModel.DataAnnotations.Schema;

	public class TechnologyDevelopments
	{
		[ForeignKey(nameof(Technology))]
		public Guid TechnologyId { get; set; }
		public virtual Technology Technology { get; set; } = null!;

		[ForeignKey(nameof(Development))]
		public Guid DevelopmentId { get; set; }

		public virtual Development Development { get; set; } = null!;
	}
}
