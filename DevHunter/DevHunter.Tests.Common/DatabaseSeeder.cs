namespace DevHunter.Tests.Common
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;

	using Data;
	using Data.Models;
	using Data.Models.Enums;

	using JobOffer = Data.Models.JobOffer;

	using static DevHunter.Common.GeneralApplicationConstants;

	public static class DatabaseSeeder
	{
		public static async void SeedDatabase(DevHunterDbContext dbContext)
		{
			await SeedUsers(dbContext);
			await SeedTechnologies(dbContext);
			await SeedDevelopments(dbContext);
			await SeedCompanies(dbContext);
			await SeedJobOffers(dbContext);
			await SeedApplications(dbContext);

			await dbContext.SaveChangesAsync();
		}

		private static async Task SeedApplications(DevHunterDbContext dbContext)
		{
			var jobOffer = await dbContext.JobOffers.FirstAsync();

			var applicatons = new JobApplication[]
			{
				new()
				{
					Email = "test@gmail.com",
					CandidateName = "candidate_name",
					JobOfferId = jobOffer.Id,
					MotivationalLetter = "...",
				}
			};

			await dbContext.JobApplications.AddRangeAsync(applicatons);
			await dbContext.SaveChangesAsync();
		}

		private static async Task SeedJobOffers(DevHunterDbContext dbContext)
		{
			var company = await dbContext.Companies.FirstAsync();
			var technology = await dbContext.Technologies.FirstAsync();

			var jobOffers = new JobOffer[]
			{
				new()
				{
					JobPosition = "c# developer",
					CreatedOn = new DateTime(2024, 4, 2),
					CompanyId = company.Id,
					PlaceToWork = "Sofia",
					JobPlace = PlaceToWork.Location,
					Description = "description",
					WorkingHours = 24,
					WorkingExperience = "5+ years work experience",
					JobOfferTechnologies = new HashSet<TechnologyJobOffers>()
					{
						new TechnologyJobOffers
						{
							TechnologyId = technology.Id,
						},
					}
				}
			};

			await dbContext.JobOffers.AddRangeAsync(jobOffers);
			await dbContext.SaveChangesAsync();
		}

		private static async Task SeedTechnologies(DevHunterDbContext dbContext)
		{
			var technologies = new Technology[]
			{
				new()
				{
					Name = "technology_1",
					ImageUrl = "image_url"
				},
				new()
				{
					Name = "technology_2",
					ImageUrl = "image_url"
				},
			};

			await dbContext.Technologies.AddRangeAsync(technologies);
			await dbContext.SaveChangesAsync();
		}

		private static async Task SeedCompanies(DevHunterDbContext dbContext)
		{
			var userCompany = await dbContext.Users.FirstAsync(u => u.UserName == "company");

			var company = new Company
			{
				Name = "name",
				EmployeeCount = 15,
				Location = "location",
				FoundedDate = new DateTime(2005, 5, 7),
				Sector = "sector",
				Activity = "activity",
				ImageUrl = "image_url",
				WebsiteUrl = "website_url",
				CreatorId = userCompany.Id,
				Description = "description"
			};

			await dbContext.Companies.AddAsync(company);
			await dbContext.SaveChangesAsync();
		}

		private static async Task SeedDevelopments(DevHunterDbContext dbContext)
		{
			var technology = await dbContext.Technologies.FirstAsync();

			var developments = new Development[]
			{
				new()
				{
					Name = "development_1",
					ImageUrl = "image_url",
				},
				new()
				{
					Name = "development_2",
					ImageUrl = "image_url",
					DevelopmentTechnologies = new HashSet<TechnologyDevelopments>
					{
						new()
						{
							TechnologyId = technology.Id,
						}
					}
				}
			};

			await dbContext.Developments.AddRangeAsync(developments);
			await dbContext.SaveChangesAsync();
		}

		private static async Task SeedUsers(DevHunterDbContext dbContext)
		{
			var roles = new IdentityRole<Guid>[]
			{
				new()
				{
					Name =  AdminRoleName
				},
				new()
				{
					Name =  CompanyRoleName
				},
			};

			var users = new ApplicationUser[]
			{
				new()
				{
					UserName = "test",
					Email = "test@gmail.com",
					PasswordHash = "hashedPassword",
				},
				new()
				{
					UserName = "company",
					Email = "company@gmail.com",
					PasswordHash = "hashedPassword"
				},
				new()
				{
					UserName = "admin",
					Email = "admin@gmail.com",
					PasswordHash = "hashedPassword"
				},
			};

			//var userRoles = new IdentityUserRole<Guid>[]
			//{
			//	new()
			//	{
			//		UserId = users[2].Id,
			//		RoleId = roles[0].Id
			//	},
			//	new()
			//	{
			//		UserId = users[1].Id,
			//		RoleId = roles[1].Id
			//	},
			//};
			//await dbContext.UserRoles.AddRangeAsync(userRoles);

			await dbContext.Roles.AddRangeAsync(roles);
			await dbContext.Users.AddRangeAsync(users);
			await dbContext.SaveChangesAsync();
		}
	}
}