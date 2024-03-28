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
			this.JobApplications = new HashSet<UserJobApplications>();
		}
		//[Required]
        //[MaxLength(FirstNameMaxLength)]
        //public string FirstName { get; set; } = null!;

        //[Required]
        //[MaxLength(LastNameMaxLength)]
        //public string LastName { get; set; } = null!;

        public virtual ICollection<SavedJobOffer> SavedJobOffers { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<UserJobApplications> JobApplications { get; set; }
    }
}