namespace DevHunter.Services.Tests
{
    using CloudinaryDotNet.Actions;
    using FluentAssertions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Moq;

    using DevHunter.Data;

    using Data;
    using Data.Interfaces;

    using static DevHunter.Tests.Common.DatabaseSeeder;
    using static Common.TestEntityConstants;

    [TestFixture]
    public class DocumentServiceTests
    {
        private DbContextOptions<DevHunterDbContext> dbOptions;
        private DevHunterDbContext dbContext;

        private IDocumentService documentService;

        private Mock<ICloudinaryService> cloudinaryMock;

        [SetUp]
        public async Task Setup()
        {
            dbOptions = new DbContextOptionsBuilder<DevHunterDbContext>()
                .UseInMemoryDatabase("DevHunterInMemory" + Guid.NewGuid())
                .Options;

            dbContext = new DevHunterDbContext(dbOptions);

            dbContext.Database.EnsureCreated();

            await SeedDatabase(dbContext);

            cloudinaryMock = new Mock<ICloudinaryService>();

            documentService =
                new DocumentService(dbContext, cloudinaryMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task UploadDocumentAsync_ShouldUploadDocument()
        {
            var fileMock = new Mock<IFormFile>();

            fileMock.Setup(x => x.FileName).Returns(TEST_DOCUMENT_URL);

            var uploadResult = new RawUploadResult
            {
                SecureUrl = new Uri(TEST_DOCUMENT_URL),
            };

            cloudinaryMock
                .Setup(x => x.UploadAsync(It.IsAny<RawUploadParams>()))
                .ReturnsAsync(uploadResult);

            var result = await documentService.UploadDocumentAsync(fileMock.Object, TEST_FOLDER);

            result.Should()
                .BeOfType<string>()
                .And
                .BeSameAs(uploadResult.SecureUrl.ToString());
        }

        [Test]
        public async Task UploadDocumentAsync_ShouldThrowExceptionForNotSuccessfulUploading()
        {
            var fileMock = new Mock<IFormFile>();

            var uploadResult = new RawUploadResult
            {
                Error = new Error()
            };

            cloudinaryMock
                .Setup(x => x.UploadAsync(It.IsAny<RawUploadParams>()))
                .ReturnsAsync(uploadResult);

            var act = async () => await documentService.UploadDocumentAsync(fileMock.Object, TEST_FOLDER);

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Test]
        public async Task AddAsync_ShouldAddCorrectDocument()
        {
            var application = await dbContext.JobApplications.FirstAsync();

            await documentService.AddAsync(TEST_DOCUMENT_URL, application.Id);

            var applicationDocuments = await dbContext.ApplicationDocuments.Where(a => a.JobApplicationId == application.Id).ToListAsync();

            applicationDocuments.Should()
                .NotBeNullOrEmpty()
                .And
                .HaveCount(1);
        }

        // ── UploadDocumentAsync – validation ────────────────────────────────────

        [Test]
        public async Task UploadDocumentAsync_ShouldThrowForOversizedFile()
        {
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(x => x.FileName).Returns("resume.pdf");
            fileMock.Setup(x => x.Length).Returns(11L * 1024 * 1024); // 11 MB

            var act = async () => await documentService.UploadDocumentAsync(fileMock.Object, TEST_FOLDER);

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("*10 MB*");
        }

        [TestCase("file.exe")]
        [TestCase("file.bat")]
        [TestCase("file.js")]
        [TestCase("file.html")]
        public async Task UploadDocumentAsync_ShouldThrowForDisallowedExtension(string fileName)
        {
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(x => x.FileName).Returns(fileName);
            fileMock.Setup(x => x.Length).Returns(100L);

            var act = async () => await documentService.UploadDocumentAsync(fileMock.Object, TEST_FOLDER);

            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("*not allowed*");
        }

        // ── AddAsync – non-existing application ────────────────────────────────

        [Test]
        public async Task AddAsync_ShouldThrowForNonExistingApplicationId()
        {
            var act = async () => await documentService.AddAsync(TEST_DOCUMENT_URL, Guid.NewGuid());

            await act.Should().ThrowAsync<Exception>();
        }

        // ── UploadAndSaveAsync ──────────────────────────────────────────────────

        [Test]
        public async Task UploadAndSaveAsync_ShouldUploadAndSaveDocument()
        {
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(x => x.FileName).Returns("resume.pdf");
            fileMock.Setup(x => x.Length).Returns(1024L);
            fileMock.Setup(x => x.OpenReadStream()).Returns(Stream.Null);

            var application = await dbContext.JobApplications.FirstAsync();

            cloudinaryMock
                .Setup(x => x.UploadAsync(It.IsAny<RawUploadParams>()))
                .ReturnsAsync(new RawUploadResult { SecureUrl = new Uri(TEST_DOCUMENT_URL) });

            await documentService.UploadAndSaveAsync(
                fileMock.Object, TEST_FOLDER, application.Id);

            bool saved = await dbContext.ApplicationDocuments
                .AnyAsync(d => d.JobApplicationId == application.Id);
            saved.Should().BeTrue();
        }

        [Test]
        public async Task UploadAndSaveAsync_ShouldRollbackCloudinaryWhenDbSaveFails()
        {
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(x => x.FileName).Returns("resume.pdf");
            fileMock.Setup(x => x.Length).Returns(1024L);
            fileMock.Setup(x => x.OpenReadStream()).Returns(Stream.Null);

            cloudinaryMock
                .Setup(x => x.UploadAsync(It.IsAny<RawUploadParams>()))
                .ReturnsAsync(new RawUploadResult { SecureUrl = new Uri(TEST_DOCUMENT_URL) });
            cloudinaryMock
                .Setup(x => x.DestroyAsync(It.IsAny<DeletionParams>()))
                .ReturnsAsync(new DeletionResult());

            // Non-existing applicationId causes AddAsync to throw, triggering Cloudinary rollback
            var act = async () => await documentService
                .UploadAndSaveAsync(fileMock.Object, TEST_FOLDER, Guid.NewGuid());

            await act.Should().ThrowAsync<Exception>();
            cloudinaryMock.Verify(x => x.DestroyAsync(It.IsAny<DeletionParams>()), Times.Once);
        }
    }
}
