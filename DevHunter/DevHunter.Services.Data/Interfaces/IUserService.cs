namespace DevHunter.Services.Data.Interfaces
{
	using Web.ViewModels.User;

	public interface IUserService
	{
		Task<IEnumerable<UserViewModel>> AllAsync();
	}
}
