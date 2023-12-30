namespace DevHunter.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using Microsoft.AspNetCore.Identity;

	using static Common.EntityValidationConstants.User;

	public class ApplicationUser : IdentityUser<Guid>
	{
		public ApplicationUser()
		{
			base.Id = Guid.NewGuid();
			this.SavedJobOffers = new HashSet<SavedJobOffer>();
		}

        //[Required]
        //[MaxLength(FirstNameMaxLength)]
        //public string FirstName { get; set; } = null!;

        //[Required]
        //[MaxLength(LastNameMaxLength)]
        //public string LastName { get; set; } = null!;

        public ICollection<SavedJobOffer> SavedJobOffers { get; set; }
    }
}
