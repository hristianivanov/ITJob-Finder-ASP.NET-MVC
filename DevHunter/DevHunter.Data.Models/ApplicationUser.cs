namespace DevHunter.Data.Models
{
	using Microsoft.AspNetCore.Identity;

	using static Common.EntityValidationConstants.User;

	public class ApplicationUser : IdentityUser<Guid>
	{
		public ApplicationUser()
		{
			base.Id = Guid.NewGuid();
			this.SavedJobOffers = new HashSet<SavedJobOffer>();
			this.Companies = new HashSet<Company>();
		}
		//[Required]
        //[MaxLength(FirstNameMaxLength)]
        //public string FirstName { get; set; } = null!;

        //[Required]
        //[MaxLength(LastNameMaxLength)]
        //public string LastName { get; set; } = null!;

        public ICollection<SavedJobOffer> SavedJobOffers { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}