namespace DevHunter.Data.Models
{
	using System.ComponentModel.DataAnnotations.Schema;

	public class CompanyTechnologies
	{
		[ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = null!;

		[ForeignKey(nameof(Technology))]	
        public Guid TechnologyId { get; set; }
        public virtual Technology Technology { get; set; } = null!;
	}
}
