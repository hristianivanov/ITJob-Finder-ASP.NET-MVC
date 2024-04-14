namespace DevHunter.Services.Tests
{
	using FluentAssertions;
	using Microsoft.EntityFrameworkCore;

	using Data;
	using Data.Interfaces;
	using Mocks;

	using DevHunter.Data;
	
	using Web.ViewModels.User;
	using Web.ViewModels.Company;
	using Web.ViewModels.JobOffer;

	using static DevHunter.Tests.Common.DatabaseSeeder;

	[TestFixture]
	public class CompanyServiceTests
	{
		private DbContextOptions<DevHunterDbContext> dbOptions;
		private DevHunterDbContext dbContext;

		private ICompanyService companyService;

		[SetUp]
		public void Setup()
		{
			dbOptions = new DbContextOptionsBuilder<DevHunterDbContext>()
				.UseInMemoryDatabase("DevHunterInMemory" + Guid.NewGuid())
				.Options;

			dbContext = new DevHunterDbContext(dbOptions);

			dbContext.Database.EnsureCreated();

			SeedDatabase(dbContext);

			companyService =
				new CompanyService(dbContext, ImageServiceMock.Instance);
		}

		[TearDown]
		public void TearDown()
		{
			dbContext.Database.EnsureDeleted();
		}

		[Test]
		public async Task AddAsync_ShouldAddCompany()
		{
			var model = new CompanyRegisterFormModel()
			{
				Name = "new_company",
				WebsiteUrl = "test_url",
			};

			var user = await dbContext.Users.FirstAsync(u => !u.Companies.Any());

			await companyService.AddAsync(model, user.Id);

			user.Companies.Should()
				.NotBeNullOrEmpty()
				.And.Contain(c => c.Name == model.Name);
		}

		[TestCase("")]
		[TestCase("  ")]
		[TestCase("invalid")]
		[TestCase(null)]
		public async Task ExistsByNameAsync_ShouldReturnFalseForNonExistingCompany(string nonExistingCompanyName)
		{
			var result = await companyService.ExistsByNameAsync(nonExistingCompanyName);
			
			result.Should().BeFalse();
		}

		[Test]
		public async Task ExistsByNameAsync_ShouldReturnTrueForExistingCompany()
		{
			var existingCompany = await dbContext.Companies.FirstAsync();

			var result = await companyService.ExistsByNameAsync(existingCompany.Name);

			result.Should().BeTrue();
		}

		[TestCase("")]
		[TestCase("  ")]
		[TestCase("invalid")]
		[TestCase(null)]
		public async Task ExistsByIdAsync_ShouldReturnFalseForNonExistingCompany(string nonExistingCompanyName)
		{
			var result = await companyService.ExistsByIdAsync(nonExistingCompanyName);

			result.Should().BeFalse();
		}

		[Test]
		public async Task ExistsByIdAsync_ShouldReturnTrueForExistingCompany()
		{
			var existingCompany = await dbContext.Companies.FirstAsync();

			var result = await companyService.ExistsByIdAsync(existingCompany.Id.ToString());

			result.Should().BeTrue();
		}

		[Test]
		public async Task GetForEditByIdAsync_ShouldReturnCorrectCompany()
		{
			var company = await dbContext.Companies.FirstAsync();

			var result = await companyService.GetForEditByIdAsync(company.Id.ToString());

			result.Should().NotBeNull()
				.And
				.BeOfType<CompanyFormModel>()
				.And
				.BeEquivalentTo(company, options => options.ExcludingMissingMembers());
		}

		[TestCase("")]
		[TestCase("  ")]
		[TestCase(null)]
		[TestCase("invalid_id")]
		public async Task GetForEditByIdAsync_ShouldThrowExceptionForNonExistingCompany(string nonExistingCompanyId)
		{
			var act = async () => await companyService.GetForEditByIdAsync(nonExistingCompanyId);

			await act.Should().ThrowAsync<InvalidOperationException>();
		}

		[Test]
		public async Task GetCompanyIdByCreatorIdAsync_ShouldReturnCompanyIdCorrect()
		{
			var companyUser = await dbContext.Users.FirstAsync(u => u.Companies.Any());

			var result = await companyService.GetCompanyIdByCreatorIdAsync(companyUser.Id.ToString());

			result.Should().NotBeNull();

			companyUser.Companies.Should().ContainSingle(c => c.Id.ToString() == result);
		}

		[Test]
		public async Task GetCompanyIdByCreatorIdAsync_ShouldThrowExceptionForNonExistingCompanyProfile()
		{
			var nonExistingUserCompanyId = "invalid";

			var act = async () => await companyService.GetCompanyIdByCreatorIdAsync(nonExistingUserCompanyId);

			await act.Should().ThrowAsync<NullReferenceException>();
		}

		[Test]
		public async Task AllAsync_ShouldReturnAllCompanies()
		{
			var companies = await dbContext.Companies.ToListAsync();

			var result = await companyService.AllAsync();

			result.Should().NotBeNull()
				.And
				.HaveSameCount(companies)
				.And
				.Equal(companies, (c1,c2) => c1.Id == c2.Id.ToString())
				.And
				.AllBeOfType<CompanyAdminViewModel>();
		}

		[Test]
		public async Task GetDetailsByIdAsync_ShouldReturnCompanyDetails()
		{
			var company = await dbContext.Companies.FirstAsync();

			var result = await companyService.GetDetailsByIdAsync(company.Id.ToString());

			result.Should()
				.NotBeNull()
				.And
				.BeOfType<CompanyDetailViewModel>();

			result.Id.Should().Be(company.Id.ToString());

			result.JobOffers.Should()
				.NotBeNull()
				.And
				.BeOfType<List<JobOfferAllViewModel>>()
				.And
				.Equal(company.JobOffers, (j1,j2) => j1.Id == j2.Id.ToString())
				.And
				.HaveCount(company.JobOffers.Count);
		}

		[Test]
		public async Task EditAsync_ShouldEditCompany()
		{
			var company = await dbContext.Companies.FirstAsync();

			var model = new CompanyFormModel()
			{
				Name = "new_name",
				Description = "new_description",
				FoundedDate = new DateTime(2022, 2, 20),
				Activity = "new_activity",
				Address = "new_address",
				EmployeesCnt = 1,
				ImageUrl = "new_image_url",
				Sector = "new_sector",
				WebsiteUrl = "new_website_url"
			};

			await companyService.EditAsync(company.Id.ToString(),model);

			var editedCompany = await dbContext.Companies.FindAsync(company.Id);

			editedCompany.Should()
				.NotBeNull()
				.And
				.BeEquivalentTo(model, options => 
					options
						.Including(x => x.Name)
						.Including(x => x.Description));
		}
	}
}
