namespace DevHunter.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	public class Development
	{
		public Development()
		{
			this.Id = Guid.NewGuid();
			this.TechnologyDevelopments = new HashSet<TechnologyDevelopments>();
		}

		[Key]
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string ImageUrl { get; set; } = null!;

		public ICollection<TechnologyDevelopments> TechnologyDevelopments { get; set; }
	}
}