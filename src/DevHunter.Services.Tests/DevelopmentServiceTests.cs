namespace DevHunter.Services.Tests
{
    using FluentAssertions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Moq;

    using Data;
    using DevHunter.Data;
    using Data.Interfaces;

    using Mocks;
    using Web.ViewModels.Development;

    using static DevHunter.Tests.Common.DatabaseSeeder;
    using static Common.TestEntityConstants;

    [TestFixture]
    public class DevelopmentServiceTests
    {
        private DbContextOptions<DevHunterDbContext> dbOptions;
        private DevHunterDbContext dbContext;

        private IDevelopmentService developmentService;

        [SetUp]
        public async Task Setup()
        {
            dbOptions = new DbContextOptionsBuilder<DevHunterDbContext>()
                .UseInMemoryDatabase("DevHunterInMemory" + Guid.NewGuid())
                .Options;

            dbContext = new DevHunterDbContext(dbOptions);

            dbContext.Database.EnsureCreated();

            await SeedDatabase(dbContext);

            developmentService =
                new DevelopmentService(dbContext, ImageServiceMock.Instance, TechnologyServiceMock.Instance);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [TestCase("")]
        [TestCase("  ")]
        [TestCase("invalid_name")]
        public async Task ExistByNameAsync_ShouldReturnFalseForNonExistingDevelopment(string nonExistingDevelopmentName)
        {
            bool result = await developmentService.ExistsByNameAsync(nonExistingDevelopmentName);

            result.Should().BeFalse();
        }

        [Test]
        public async Task ExistByNameAsync_ShouldThrowExceptionForNonExistingDevelopment()
        {
            var act = async () => await developmentService.ExistsByNameAsync(null!);

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Test]
        public async Task ExistByNameAsync_ShouldReturnTrueForExistingDevelopment()
        {
            string existingDevelopmentName = "development_1";

            bool result = await developmentService.ExistsByNameAsync(existingDevelopmentName);

            result.Should().BeTrue();
        }


        [Test]
        public async Task ExistsByIdAsync_ShouldReturnTrueForExistingDevelopment()
        {
            var existingDevelopment = await dbContext.Developments.FirstAsync();

            bool result = await developmentService.ExistsByIdAsync(existingDevelopment.Id);

            result.Should().BeTrue();
        }

        [Test]
        public async Task ExistsByIdAsync_ShouldReturnFalseForNonExistingDevelopment()
        {
            bool result = await developmentService.ExistsByIdAsync(Guid.NewGuid());

            result.Should().BeFalse();
        }

        [Test]
        public async Task AddAsync_ShouldAddNewDevelopment()
        {
            var development = new DevelopmentFormModel()
            {
                Name = "new_development",
                Image = null!
            };

            await developmentService.AddAsync(development);

            var addedDevelopment = await dbContext
                .Developments
                .FirstOrDefaultAsync(d => d.Name == development.Name);

            addedDevelopment.Should().NotBeNull();

            addedDevelopment!.ImageUrl.Should().Be(TEST_IMAGE_URL,
                "Uploading development image is not triggered!");

            development.Should().BeEquivalentTo(addedDevelopment, options =>
                options.Including(d => d.Name));
        }

        [Test]
        public async Task AllAsync_ShouldReturnAllDevelopments()
        {
            var developments = await dbContext.Developments
                .ToListAsync();

            var result = await developmentService.AllAsync();

            result.Should().NotBeNullOrEmpty();

            result.Should()
                .Equal(developments, (d1, d2) => d1.Id == d2.Id.ToString());
        }

        [Test]
        public async Task AllAsync_ShouldCountCorrectAllDevelopmentTechnologies()
        {
            var developments = await dbContext.Developments
                .Include(d => d.DevelopmentTechnologies)
                .ToListAsync();

            var result = await developmentService.AllAsync();

            result.Should().HaveSameCount(developments);

            foreach (var dev in developments)
            {
                var vm = result.First(r => r.Id == dev.Id.ToString());
                vm.Count.Should().Be(dev.DevelopmentTechnologies.Count,
                    $"technology count for '{dev.Name}' should match seeded data");
            }
        }

        [Test]
        public async Task AllAsync_ShouldOrderCorrectDevelopments()
        {
            var expectedOrder = await dbContext.Developments
                .OrderBy(d => d.SortOrder)
                .Select(d => d.Id.ToString())
                .ToListAsync();

            var result = (await developmentService.AllAsync())
                .Select(d => d.Id)
                .ToList();

            result.Should().ContainInOrder(expectedOrder);
        }


        [Test]
        public async Task GetByIdAsync_ShouldReturnCorrectDevelopment()
        {
            var development = await dbContext.Developments.FirstAsync();

            var result = await developmentService.GetByIdAsync(development.Id);

            result.Should().NotBeNull()
                .And
                .BeOfType<DevelopmentOfferViewModel>()
                .And
                .BeEquivalentTo(development, options =>
                    options
                        .Including(x => x.Name)
                        .Including(x => x.ImageUrl));
        }

        [Test]
        public async Task GetByIdAsync_ShouldThrowExceptionForNonExistingId()
        {
            var act = async () => await developmentService.GetByIdAsync(Guid.NewGuid());

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Test]
        public async Task GetForEditByIdAsync_ShouldReturnCorrectDevelopment()
        {
            var development = await dbContext.Developments.FirstAsync();

            var result = await developmentService.GetForEditByIdAsync(development.Id);


            result.Should().NotBeNull()
                .And
                .BeOfType<DevelopmentEditFormModel>()
                .And
                .BeEquivalentTo(development, options =>
                    options
                        .Including(x => x.Name)
                        .Including(x => x.ImageUrl));
        }

        [Test]
        public async Task GetForEditByIdAsync_ShouldThrowExceptionForNonExistingId()
        {
            var act = async () => await developmentService.GetForEditByIdAsync(Guid.NewGuid());

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Test]
        public async Task EditDevelopmentAsync_ShouldEditCorrectDevelopment()
        {
            var development = await dbContext.Developments.FirstAsync();

            var model = new DevelopmentEditFormModel
            {
                Name = "new_development_name",
                Image = new FormFile(Stream.Null, 0, 0, "test.jpg", "test.jpg")
            };

            await developmentService.EditDevelopmentAsync(development.Id, model);

            var editedDevelopment = await dbContext.Developments.FindAsync(development.Id);

            editedDevelopment.Should()
                .BeEquivalentTo(model, options => options.ExcludingMissingMembers())
                .And
                .NotBeNull();
        }

        [Test]
        public async Task EditDevelopmentAsync_ShouldThrowExceptionForNonExistingId()
        {
            var act = async () => await developmentService.EditDevelopmentAsync(Guid.NewGuid(), null!);

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Test]
        public async Task EditDevelopmentAsync_ShouldThrowExceptionForNullableModel()
        {
            var development = await dbContext.Developments.FirstAsync();

            var act = async () => await developmentService.EditDevelopmentAsync(development.Id, null!);

            await act.Should().ThrowAsync<NullReferenceException>();
        }

        [Test]
        public async Task DeleteByIdAsync_ShouldDeleteCorrectDevelopment()
        {
            var development = await dbContext.Developments.FirstAsync();

            await developmentService.DeleteByIdAsync(development.Id);

            var deletedDevelopment = await dbContext.Developments.FindAsync(development.Id);

            deletedDevelopment.Should().BeNull();
        }

        [Test]
        public async Task DeleteByIdAsync_ShouldThrowExceptionForNonExistingId()
        {
            var act = async () => await developmentService.DeleteByIdAsync(Guid.NewGuid());

            await act.Should().ThrowAsync<InvalidOperationException>();
        }
    }
}
