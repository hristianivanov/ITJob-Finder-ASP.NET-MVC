namespace DevHunter.Services.Data
{
	using Microsoft.EntityFrameworkCore;

	using DevHunter.Data;
	using DevHunter.Data.Models;
	using Interfaces;
	using Web.ViewModels.User;

	public class UserService : IUserService
	{
		private readonly DevHunterDbContext context;

		public UserService(DevHunterDbContext context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<UserViewModel>> AllAsync()
		{
			IQueryable<ApplicationUser> usersQuery = this.context.Users;

			//if (!string.IsNullOrEmpty(searchString))
			//{
			//	usersQuery = usersQuery.Where(u =>
			//		u.FirstName.Contains(searchString) ||
			//		u.LastName.Contains(searchString) ||
			//		u.Email.Contains(searchString) ||
			//		u.PhoneNumber.Contains(searchString));
			//}

			ICollection<UserViewModel> allUsers = await usersQuery
				.Select(u => new UserViewModel()
				{
					Id = u.Id.ToString(),
					Email = u.Email,
					FullName = $"{u.FirstName} {u.LastName}",
					IsCompany = u.Companies.Any(c => c.CreatorId == u.Id),
				})
				.ToListAsync();

			return allUsers;
		}

		public async Task<ApplicationUser> GetUserByIdAsync(string userId)
		{
			var user = await this.context.Users.FirstAsync(u => u.Id.ToString() == userId);

			return user;
		}
	}
}
