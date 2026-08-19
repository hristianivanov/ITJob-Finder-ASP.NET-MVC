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

    using Mocks;

    using static DevHunter.Tests.Common.DatabaseSeeder;

    [TestFixture]
    public class DevelopmentServiceCachingTests
    {
        private DbContextOptions<DevHunterDbContext> dbOptions;
        private DevHunterDbContext dbContext;
        private IMemoryCache cache;
        private IDevelopmentService developmentService;

        [SetUp]
        public async Task Setup()
        {
            dbOptions = new DbContextOptionsBuilder<DevHunterDbContext>()
                .UseInMemoryDatabase("DevHunterDevCacheInMemory" + Guid.NewGuid())
                .Options;

            dbContext = new DevHunterDbContext(dbOptions);
            dbContext.Database.EnsureCreated();

            await SeedDatabase(dbContext);

            cache = new MemoryCache(Options.Create(new MemoryCacheOptions()));
            developmentService = new DevelopmentService(dbContext, ImageServiceMock.Instance, TechnologyServiceMock.Instance, cache);
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
            await developmentService.AllAsync();

            cache.TryGetValue("all_developments", out var cached).Should().BeTrue();
            cached.Should().NotBeNull();
        }

        [Test]
        public async Task AllAsync_ShouldReturnCachedResultOnSecondCall()
        {
            var first = await developmentService.AllAsync();
            var second = await developmentService.AllAsync();

            second.Should().BeSameAs(first);
        }

        [Test]
        public async Task AddAsync_ShouldInvalidateCache()
        {
            await developmentService.AllAsync();
            cache.TryGetValue("all_developments", out _).Should().BeTrue();

            await developmentService.AddAsync(new Web.ViewModels.Development.DevelopmentFormModel
            {
                Name = "new_dev",
                Image = null!
            });

            cache.TryGetValue("all_developments", out _).Should().BeFalse();
        }

        [Test]
        public async Task EditDevelopmentAsync_ShouldInvalidateCache()
        {
            var development = await dbContext.Developments.FirstAsync();
            await developmentService.AllAsync();
            cache.TryGetValue("all_developments", out _).Should().BeTrue();

            await developmentService.EditDevelopmentAsync(development.Id,
                new Web.ViewModels.Development.DevelopmentEditFormModel { Name = "changed" });

            cache.TryGetValue("all_developments", out _).Should().BeFalse();
        }

        [Test]
        public async Task DeleteByIdAsync_ShouldInvalidateCache()
        {
            var development = await dbContext.Developments.FirstAsync();
            await developmentService.AllAsync();
            cache.TryGetValue("all_developments", out _).Should().BeTrue();

            await developmentService.DeleteByIdAsync(development.Id);

            cache.TryGetValue("all_developments", out _).Should().BeFalse();
        }

        [Test]
        public async Task AllAsync_ShouldReflectFreshDataAfterCacheInvalidation()
        {
            var before = await developmentService.AllAsync();
            int countBefore = before.Count;

            var first = await dbContext.Developments.FirstAsync();
            await developmentService.DeleteByIdAsync(first.Id);

            var after = await developmentService.AllAsync();

            after.Should().HaveCount(countBefore - 1);
        }
    }
}
