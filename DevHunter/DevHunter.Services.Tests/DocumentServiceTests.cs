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
		public void Setup()
		{
			dbOptions = new DbContextOptionsBuilder<DevHunterDbContext>()
				.UseInMemoryDatabase("DevHunterInMemory" + Guid.NewGuid())
				.Options;

			dbContext = new DevHunterDbContext(dbOptions);

			dbContext.Database.EnsureCreated();

			SeedDatabase(dbContext);

			cloudinaryMock = new Mock<ICloudinaryService>();

			documentService =
				new DocumentService(dbContext,cloudinaryMock.Object);
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

			var uploadResult = new RawUploadResult
			{
				SecureUrl = new Uri(TEST_DOCUMENT_URL)
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

			var act =  async ()=> await documentService.UploadDocumentAsync(fileMock.Object, TEST_FOLDER);

			await act.Should().ThrowAsync<InvalidOperationException>();
		}

		[Test]
		public async Task AddAsync_ShouldAddCorrectDocument()
		{
			var application = await dbContext.JobApplications.FirstAsync();

			await documentService.AddAsync(TEST_DOCUMENT_URL, application.Id.ToString());

			var applicationDocuments = await dbContext.ApplicationDocuments.Where(a => a.JobApplicationId == application.Id).ToListAsync();

			applicationDocuments.Should()
				.NotBeNullOrEmpty()
				.And
				.HaveCount(1);
		}
	}
}
