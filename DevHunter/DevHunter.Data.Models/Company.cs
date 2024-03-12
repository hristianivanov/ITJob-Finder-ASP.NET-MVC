namespace DevHunter.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Company
	{
		public Company()
		{
			this.Id = Guid.NewGuid();
			this.UsedTechnologies = new HashSet<CompanyTechnologies>();
		}

		[Key]
		public Guid Id { get; set; }

		public string Name { get; set; } = null!;

		public int? EmployeeCount { get; set; }

		public int? WorkingHoursPerDay { get; set; }

		public string? Location { get; set; } = null!;

		public DateTime? FoundedYear { get; set; }

		public string? Sector { get; set; } = null!;

		public string? Activity { get; set; } = null!;

		public string? ImageUrl { get; set; }

        public string? WebsiteUrl { get; set; }

		[ForeignKey(nameof(Creator))]
        public Guid CreatorId { get; set; }

        public ApplicationUser Creator { get; set; } = null!;

        public ICollection<CompanyTechnologies> UsedTechnologies { get; set; }
	}
}