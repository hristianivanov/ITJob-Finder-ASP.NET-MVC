namespace DevHunter.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using Complex;

	public class Technology
	{
		public Technology()
		{
			this.Id = Guid.NewGuid();
			this.Image = new ImageData();
			this.TechnologyDevelopments = new HashSet<TechnologyDevelopments>();
			this.CompanyTechnologies = new HashSet<CompanyTechnologies>();
			this.TechnologyJobOffers = new HashSet<TechnologyJobOffers>();
		}

		[Key]
		public Guid Id { get; set; }

		public string Name { get; set; } = null!;

		public ImageData Image { get; set; }

		public ICollection<TechnologyJobOffers> TechnologyJobOffers { get; set; }
		public ICollection<CompanyTechnologies> CompanyTechnologies { get; set; }
		public ICollection<TechnologyDevelopments> TechnologyDevelopments { get; set; }
	}
}