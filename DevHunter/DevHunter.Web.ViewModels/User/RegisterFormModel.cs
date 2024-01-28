namespace DevHunter.Web.ViewModels.User
{
	using System.ComponentModel.DataAnnotations;

	using static Common.EntityValidationConstants.User;

	public class RegisterFormModel
	{
		//[Required]
		//[StringLength(FirstNameMaxLength,MinimumLength = FirstNameMinLength)]
		//public string FirstName { get; set; } = null!;

		//[Required]
		//[StringLength(LastNameMaxLength,MinimumLength = LastNameMinLength)]
		//public string LastName { get; set; } = null!;

		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; } = null!;

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		[StringLength(PasswordMaxLength,MinimumLength = PasswordMinLength)]
		public string Password { get; set; } = null!;
	}
}