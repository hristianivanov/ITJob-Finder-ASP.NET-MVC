namespace DevHunter.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Company
    {
        public Company()
        {
            this.Id = Guid.NewGuid();
            this.UsedTechnologies = new HashSet<Technology>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public int EmployeeCount { get; set; }

        public int WorkingHoursPerDay { get; set; }

        public string Location { get; set; } = null!;

        public DateTime FoundedYear { get; set; }

        public string Sector { get; set; } = null!;

        public string Activity { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public ICollection<Technology> UsedTechnologies { get; set; }
    }
}
