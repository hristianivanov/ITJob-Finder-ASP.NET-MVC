namespace DevHunter.Web.ViewModels.User
{
	public class UserManageFormModel
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }

		public string? Email { get; set; }

		public UserChangePasswordFormModel ChangePasswordModel { get; set; }
	}
}
