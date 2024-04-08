namespace DevHunter.Web.ViewModels.User
{
	public class UserManageFormModel
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }

        public string Email { get; set; } = null!;

        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
