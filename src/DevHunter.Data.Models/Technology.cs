namespace DevHunter.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	public class Technology
	{
		public Technology()
		{
			this.Id = Guid.NewGuid();
			this.TechnologyDevelopments = new HashSet<TechnologyDevelopments>();
			this.CompanyTechnologies = new HashSet<CompanyTechnologies>();
			this.TechnologyJobOffers = new HashSet<TechnologyJobOffers>();
		}

		[Key]
		public Guid Id { get; set; }

		public string Name { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;

		public virtual ICollection<TechnologyJobOffers> TechnologyJobOffers { get; set; }
		public virtual ICollection<CompanyTechnologies> CompanyTechnologies { get; set; }
		public virtual ICollection<TechnologyDevelopments> TechnologyDevelopments { get; set; }
	}
}