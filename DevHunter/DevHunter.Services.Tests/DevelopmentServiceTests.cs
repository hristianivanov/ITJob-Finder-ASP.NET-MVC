using Moq;

namespace DevHunter.Services.Tests
{
	using Microsoft.EntityFrameworkCore;

	using Data;
	using DevHunter.Data;
	using Data.Interfaces;

	using static DatabaseSeeder;

	[TestFixture]
	public class DevelopmentServiceTests
	{
		private DbContextOptions<DevHunterDbContext> dbOptions;
		private DevHunterDbContext dbContext;

		private IDevelopmentService developmentService;

		private Mock<IImageService> imageServiceMock;
		private Mock<ITechnologyService> technologyServiceMock;

		[SetUp]
		public void Setup()
		{
			this.dbOptions = new DbContextOptionsBuilder<DevHunterDbContext>()
				.UseInMemoryDatabase("DevHunterInMemory" + Guid.NewGuid())
				.Options;

			this.dbContext = new DevHunterDbContext(this.dbOptions);

			this.dbContext.Database.EnsureCreated();

			SeedDatabase(this.dbContext);

			this.imageServiceMock = new Mock<IImageService>();
			this.technologyServiceMock = new Mock<ITechnologyService>();

			this.developmentService = new DevelopmentService(this.dbContext, imageServiceMock.Object, technologyServiceMock.Object);
		}

		[TearDown]
		public void TearDown()
		{
			dbContext.Database.EnsureDeleted();
		}

		[Test]
		public async Task ExistByNameAsync_ShouldReturnFalseForNonExistingDevelopment()
		{
			string nonExistingDevelopmentName = "invalid";

			bool result = await developmentService.ExistsByNameAsync(nonExistingDevelopmentName);

			Assert.IsFalse(result);
		}
	}
}