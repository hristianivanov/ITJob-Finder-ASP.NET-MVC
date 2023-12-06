namespace DevHunter.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Development
    {
        public Development()
        {
            this.Id = Guid.NewGuid();
            this.Technologies = new HashSet<Technology>();
        }

        [Key]
        public Guid Id { get; set; }

        public string ImageUrl { get; set; } = null!;

        public ICollection<Technology> Technologies { get; set; }
    }
}