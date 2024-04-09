namespace DevHunter.Web.ViewModels.User
{
	using System.ComponentModel.DataAnnotations;

	public class UserChangePasswordFormModel
	{
		[Required(ErrorMessage = "The Password field is required.")]
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;

		[DataType(DataType.Password)]
		[Required(ErrorMessage = "The Confirm Password field is required.")]
		[Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; } = null!;
	}
}
