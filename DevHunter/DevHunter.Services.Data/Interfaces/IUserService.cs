namespace DevHunter.Services.Data.Interfaces
{
	using DevHunter.Data.Models;
	using Web.ViewModels.User;

	public interface IUserService
	{
		Task<IEnumerable<UserViewModel>> AllAsync();
		Task<UserManageFormModel> GetUserByIdAsync(string userId);
	}
}
