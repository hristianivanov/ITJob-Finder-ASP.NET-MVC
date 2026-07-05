namespace DevHunter.Services.Tests
{
    using FluentAssertions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Moq;

    using Data;
    using Data.Interfaces;

    using DevHunter.Data;

    using Web.ViewModels.Technology;

    using static DevHunter.Tests.Common.DatabaseSeeder;

    [TestFixture]
    public class TechnologyServiceTests
    {
        private DbContextOptions<DevHunterDbContext> dbOptions;
        private DevHunterDbContext dbContext;

        private ITechnologyService technologyService;
        private Mock<IImageService> imageServiceMock;

        [SetUp]
        public async Task Setup()
        {
            dbOptions = new DbContextOptionsBuilder<DevHunterDbContext>()
                .UseInMemoryDatabase("DevHunterInMemory" + Guid.NewGuid())
                .Options;

            dbContext = new DevHunterDbContext(dbOptions);
            dbContext.Database.EnsureCreated();

            await SeedDatabase(dbContext);

            imageServiceMock = new Mock<IImageService>();
            imageServiceMock
                .Setup(s => s.UploadImage(It.IsAny<IFormFile>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(Common.TestEntityConstants.TEST_CLOUDINARY_IMAGE_URL);
            imageServiceMock
                .Setup(s => s.EditImage(It.IsAny<IFormFile>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(Common.TestEntityConstants.TEST_CLOUDINARY_IMAGE_URL);

            technologyService = new TechnologyService(dbContext, imageServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        // ── TechnologyExistsByNameAsync ──────────────────────────────────────────

        [Test]
        public async Task TechnologyExistsByNameAsync_ShouldReturnTrueForExistingName()
        {
            var technology = await dbContext.Technologies.FirstAsync();

            var result = await technologyService.TechnologyExistsByNameAsync(technology.Name);

            result.Should().BeTrue();
        }

        [TestCase("")]
        [TestCase("  ")]
        [TestCase("nonexistent_tech")]
        public async Task TechnologyExistsByNameAsync_ShouldReturnFalseForNonExistingName(string name)
        {
            var result = await technologyService.TechnologyExistsByNameAsync(name);

            result.Should().BeFalse();
        }

        [Test]
        public async Task TechnologyExistsByNameAsync_ShouldBeCaseInsensitive()
        {
            var technology = await dbContext.Technologies.FirstAsync();

            var result = await technologyService.TechnologyExistsByNameAsync(technology.Name.ToUpper());

            result.Should().BeTrue();
        }

        // ── AddAsync ────────────────────────────────────────────────────────────

        [Test]
        public async Task AddAsync_ShouldAddTechnologyWithoutDevelopmentLink()
        {
            var model = new TechnologyFormModel
            {
                Name = "new_technology",
                Image = Mock.Of<IFormFile>()
            };

            await technologyService.AddAsync(model, null);

            var added = await dbContext.Technologies.FirstOrDefaultAsync(t => t.Name == model.Name);
            added.Should().NotBeNull();
            added!.ImageUrl.Should().Be(Common.TestEntityConstants.TEST_CLOUDINARY_IMAGE_URL);
        }

        [Test]
        public async Task AddAsync_ShouldLinkTechnologyToDevelopment()
        {
            var development = await dbContext.Developments.FirstAsync();
            var model = new TechnologyFormModel
            {
                Name = "linked_technology",
                Image = Mock.Of<IFormFile>()
            };

            await technologyService.AddAsync(model, development.Id);

            var added = await dbContext.Technologies.FirstOrDefaultAsync(t => t.Name == model.Name);
            added.Should().NotBeNull();

            bool linked = await dbContext.TechnologiesDevelopments
                .AnyAsync(td => td.DevelopmentId == development.Id && td.TechnologyId == added!.Id);
            linked.Should().BeTrue();
        }

        [Test]
        public async Task AddAsync_ShouldNotCreateDevelopmentLinkForNonExistingDevelopmentId()
        {
            int countBefore = await dbContext.TechnologiesDevelopments.CountAsync();
            var model = new TechnologyFormModel
            {
                Name = "orphan_technology",
                Image = Mock.Of<IFormFile>()
            };

            await technologyService.AddAsync(model, Guid.NewGuid());

            int countAfter = await dbContext.TechnologiesDevelopments.CountAsync();
            countAfter.Should().Be(countBefore);
        }

        // ── AllAsync ────────────────────────────────────────────────────────────

        [Test]
        public async Task AllAsync_ShouldReturnAllTechnologies()
        {
            var dbTechs = await dbContext.Technologies.ToListAsync();

            var result = await technologyService.AllAsync();

            result.Should().NotBeNullOrEmpty()
                .And.HaveSameCount(dbTechs)
                .And.AllBeOfType<TechnologyViewModel>()
                .And.Equal(dbTechs, (vm, t) => vm.Id == t.Id.ToString());
        }

        // ── ExistsByIdAsync ─────────────────────────────────────────────────────

        [Test]
        public async Task ExistsByIdAsync_ShouldReturnTrueForExistingId()
        {
            var technology = await dbContext.Technologies.FirstAsync();

            var result = await technologyService.ExistsByIdAsync(technology.Id);

            result.Should().BeTrue();
        }

        [Test]
        public async Task ExistsByIdAsync_ShouldReturnFalseForNonExistingId()
        {
            var result = await technologyService.ExistsByIdAsync(Guid.NewGuid());

            result.Should().BeFalse();
        }

        // ── GetForEditByIdAsync ─────────────────────────────────────────────────

        [Test]
        public async Task GetForEditByIdAsync_ShouldReturnCorrectTechnology()
        {
            var technology = await dbContext.Technologies.FirstAsync();

            var result = await technologyService.GetForEditByIdAsync(technology.Id);

            result.Should().NotBeNull().And.BeOfType<TechnologyEditFormModel>();
            result.Name.Should().Be(technology.Name);
            result.ImageUrl.Should().Be(technology.ImageUrl);
        }

        [Test]
        public async Task GetForEditByIdAsync_ShouldThrowForNonExistingId()
        {
            var act = async () => await technologyService.GetForEditByIdAsync(Guid.NewGuid());

            await act.Should().ThrowAsync<Exception>();
        }

        // ── EditTechnologyAsync ─────────────────────────────────────────────────

        [Test]
        public async Task EditTechnologyAsync_ShouldEditName()
        {
            var technology = await dbContext.Technologies.FirstAsync();
            var model = new TechnologyEditFormModel { Name = "edited_name" };

            await technologyService.EditTechnologyAsync(technology.Id, model);

            var edited = await dbContext.Technologies.FindAsync(technology.Id);
            edited!.Name.Should().Be("edited_name");
        }

        [Test]
        public async Task EditTechnologyAsync_ShouldEditImageWhenProvided()
        {
            var technology = await dbContext.Technologies.FirstAsync();
            var model = new TechnologyEditFormModel
            {
                Name = technology.Name,
                Image = Mock.Of<IFormFile>()
            };

            await technologyService.EditTechnologyAsync(technology.Id, model);

            imageServiceMock.Verify(
                s => s.EditImage(It.IsAny<IFormFile>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Once);
        }

        [Test]
        public async Task EditTechnologyAsync_ShouldSkipImageServiceWhenNoImageProvided()
        {
            var technology = await dbContext.Technologies.FirstAsync();
            var model = new TechnologyEditFormModel { Name = technology.Name };

            await technologyService.EditTechnologyAsync(technology.Id, model);

            imageServiceMock.Verify(
                s => s.EditImage(It.IsAny<IFormFile>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Never);
        }

        // ── DeleteByIdAsync ─────────────────────────────────────────────────────

        [Test]
        public async Task DeleteByIdAsync_ShouldDeleteTechnology()
        {
            var technology = await dbContext.Technologies.LastAsync();

            await technologyService.DeleteByIdAsync(technology.Id);

            var deleted = await dbContext.Technologies.FindAsync(technology.Id);
            deleted.Should().BeNull();
        }

        [Test]
        public async Task DeleteByIdAsync_ShouldIgnoreNonExistingId()
        {
            int countBefore = await dbContext.Technologies.CountAsync();

            await technologyService.DeleteByIdAsync(Guid.NewGuid());

            int countAfter = await dbContext.Technologies.CountAsync();
            countAfter.Should().Be(countBefore);
        }

        // ── AllByDevelopmentAsync ───────────────────────────────────────────────

        [Test]
        public async Task AllByDevelopmentAsync_ShouldReturnTechnologiesForDevelopment()
        {
            var development = await dbContext.Developments
                .FirstAsync(d => d.DevelopmentTechnologies.Any());

            var result = await technologyService.AllByDevelopmentAsync(development.Id);

            result.Should().NotBeNullOrEmpty()
                .And.HaveCount(development.DevelopmentTechnologies.Count)
                .And.AllBeOfType<TechnologyViewModel>();
        }

        [Test]
        public async Task AllByDevelopmentAsync_ShouldReturnEmptyForDevelopmentWithNoTechnologies()
        {
            var development = await dbContext.Developments
                .FirstAsync(d => !d.DevelopmentTechnologies.Any());

            var result = await technologyService.AllByDevelopmentAsync(development.Id);

            result.Should().BeEmpty();
        }

        [Test]
        public async Task AllByDevelopmentAsync_ShouldReturnEmptyForNonExistingId()
        {
            var result = await technologyService.AllByDevelopmentAsync(Guid.NewGuid());

            result.Should().BeEmpty();
        }

        // ── AllByJobOfferIdAsync ────────────────────────────────────────────────

        [Test]
        public async Task AllByJobOfferIdAsync_ShouldReturnTechnologiesForJobOffer()
        {
            var jobOffer = await dbContext.JobOffers
                .Include(j => j.JobOfferTechnologies)
                .FirstAsync();

            var result = await technologyService.AllByJobOfferIdAsync(jobOffer.Id);

            result.Should().NotBeNullOrEmpty()
                .And.HaveCount(jobOffer.JobOfferTechnologies.Count)
                .And.AllBeOfType<TechnologyViewModel>()
                .And.Equal(jobOffer.JobOfferTechnologies, (vm, jot) => vm.Id == jot.TechnologyId.ToString());
        }

        [Test]
        public async Task AllByJobOfferIdAsync_ShouldReturnEmptyForNonExistingJobOffer()
        {
            var result = await technologyService.AllByJobOfferIdAsync(Guid.NewGuid());

            result.Should().BeEmpty();
        }

        // ── AllWithoutJobOfferOnesAsync ─────────────────────────────────────────

        [Test]
        public async Task AllWithoutJobOfferOnesAsync_ShouldExcludeAlreadyAttachedTechnologies()
        {
            var jobOffer = await dbContext.JobOffers
                .Include(j => j.JobOfferTechnologies)
                .FirstAsync();

            var attachedIds = jobOffer.JobOfferTechnologies
                .Select(t => t.TechnologyId)
                .ToHashSet();

            var result = await technologyService.AllWithoutJobOfferOnesAsync(jobOffer.Id);

            result.Should().NotContain(vm => attachedIds.Contains(Guid.Parse(vm.Id)),
                "already attached technologies must be excluded");
        }

        [Test]
        public async Task AllWithoutJobOfferOnesAsync_ShouldReturnOnlyUnattachedTechnologies()
        {
            var jobOffer = await dbContext.JobOffers
                .Include(j => j.JobOfferTechnologies)
                .FirstAsync();

            int totalTechnologies = await dbContext.Technologies.CountAsync();
            int attachedCount = jobOffer.JobOfferTechnologies.Count;

            var result = await technologyService.AllWithoutJobOfferOnesAsync(jobOffer.Id);

            result.Should().HaveCount(totalTechnologies - attachedCount);
        }
    }
}
