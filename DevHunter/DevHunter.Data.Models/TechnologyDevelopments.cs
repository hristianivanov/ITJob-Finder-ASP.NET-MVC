namespace DevHunter.Data.Models
{
	using System.ComponentModel.DataAnnotations.Schema;

	public class TechnologyDevelopments
	{
		[ForeignKey(nameof(Technology))]
		public Guid TechnologyId { get; set; }
		public Technology Technology { get; set; } = null!;

		[ForeignKey(nameof(Development))]
		public Guid DevelopmentId { get; set; }

		public Development Development { get; set; } = null!;
	}
}
