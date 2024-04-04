namespace DevHunter.Data.Configurations
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class UserRolesEntityConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
	{
		public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
		{
			builder.HasData(GetUserRoles());
		}

		private IEnumerable<IdentityUserRole<Guid>> GetUserRoles()
		{
			return new HashSet<IdentityUserRole<Guid>>()
			{
				new IdentityUserRole<Guid>()
				{
					UserId = Guid.Parse("89DCCCDC-645E-4968-822E-5A3761805A21"),
					RoleId = Guid.Parse("77362B2F-4904-44B3-2D0E-08DC533C8797"),
				},
				new IdentityUserRole<Guid>()
				{
					UserId = Guid.Parse("8BC9F34C-E049-478C-9D62-60B5A7E1AE87"),
					RoleId = Guid.Parse("77362B2F-4904-44B3-2D0E-08DC533C8797"),
				},
				new IdentityUserRole<Guid>()
				{
					UserId = Guid.Parse("9231CC3C-ED70-4A91-AF87-8D70252D9B50"),
					RoleId = Guid.Parse("77362B2F-4904-44B3-2D0E-08DC533C8797"),
				},
				new IdentityUserRole<Guid>()
				{
					UserId = Guid.Parse("2F4BBC62-7DB6-4E14-8790-EA0C3D704158"),
					RoleId = Guid.Parse("77362B2F-4904-44B3-2D0E-08DC533C8797"),
				},
			};
		}
	}
}
