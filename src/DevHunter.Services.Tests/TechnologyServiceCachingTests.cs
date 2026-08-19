namespace DevHunter.Services.Tests
{
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Options;
    using Moq;

    using Data;
    using Data.Interfaces;
    using DevHunter.Data;

    using static DevHunter.Tests.Common.DatabaseSeeder;

    [TestFixture]
    public class TechnologyServiceCachingTests
    {
        private DbContextOptions<DevHunterDbContext> dbOptions;
        private DevHunterDbContext dbContext;
        private IMemoryCache cache;
        private ITechnologyService technologyService;

        [SetUp]
        public async Task Setup()
        {
            dbOptions = new DbContextOptionsBuilder<DevHunterDbContext>()
                .UseInMemoryDatabase("DevHunterCacheInMemory" + Guid.NewGuid())
                .Options;

            dbContext = new DevHunterDbContext(dbOptions);
            dbContext.Database.EnsureCreated();

            await SeedDatabase(dbContext);

            cache = new MemoryCache(Options.Create(new MemoryCacheOptions()));

            var imageServiceMock = new Mock<IImageService>();
            imageServiceMock
                .Setup(s => s.UploadImage(It.IsAny<Microsoft.AspNetCore.Http.IFormFile>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(Common.TestEntityConstants.TEST_CLOUDINARY_IMAGE_URL);
            imageServiceMock
                .Setup(s => s.EditImage(It.IsAny<Microsoft.AspNetCore.Http.IFormFile>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(Common.TestEntityConstants.TEST_CLOUDINARY_IMAGE_URL);

            technologyService = new TechnologyService(dbContext, imageServiceMock.Object, cache);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            cache.Dispose();
        }

        [Test]
        public async Task AllAsync_ShouldPopulateCache()
        {
            await technologyService.AllAsync();

            cache.TryGetValue("all_technologies", out var cached).Should().BeTrue();
            cached.Should().NotBeNull();
        }

        [Test]
        public async Task AllAsync_ShouldReturnCachedResultOnSecondCall()
        {
            var first = await technologyService.AllAsync();
            var second = await technologyService.AllAsync();

            second.Should().BeSameAs(first);
        }

        [Test]
        public async Task AddAsync_ShouldInvalidateCache()
        {
            await technologyService.AllAsync();
            cache.TryGetValue("all_technologies", out _).Should().BeTrue();

            var model = new Web.ViewModels.Technology.TechnologyFormModel
            {
                Name = "new_tech",
                Image = Mock.Of<Microsoft.AspNetCore.Http.IFormFile>()
            };

            await technologyService.AddAsync(model, null);

            cache.TryGetValue("all_technologies", out _).Should().BeFalse();
        }

        [Test]
        public async Task EditTechnologyAsync_ShouldInvalidateCache()
        {
            var technology = await dbContext.Technologies.FirstAsync();
            await technologyService.AllAsync();
            cache.TryGetValue("all_technologies", out _).Should().BeTrue();

            await technologyService.EditTechnologyAsync(technology.Id,
                new Web.ViewModels.Technology.TechnologyEditFormModel { Name = "changed" });

            cache.TryGetValue("all_technologies", out _).Should().BeFalse();
        }

        [Test]
        public async Task DeleteByIdAsync_ShouldInvalidateCache()
        {
            var technology = await dbContext.Technologies.LastAsync();
            await technologyService.AllAsync();
            cache.TryGetValue("all_technologies", out _).Should().BeTrue();

            await technologyService.DeleteByIdAsync(technology.Id);

            cache.TryGetValue("all_technologies", out _).Should().BeFalse();
        }

        [Test]
        public async Task AllAsync_ShouldReflectFreshDataAfterCacheInvalidation()
        {
            var before = (await technologyService.AllAsync()).ToList();
            var firstId = Guid.Parse(before.First().Id);

            await technologyService.DeleteByIdAsync(firstId);

            var after = (await technologyService.AllAsync()).ToList();

            after.Should().HaveCount(before.Count - 1);
        }
    }
}
