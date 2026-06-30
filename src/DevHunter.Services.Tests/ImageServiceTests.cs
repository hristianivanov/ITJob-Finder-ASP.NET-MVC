namespace DevHunter.Services.Tests
{
    using CloudinaryDotNet.Actions;
    using FluentAssertions;
    using Microsoft.AspNetCore.Http;
    using Moq;

    using Data;
    using Data.Interfaces;

    using static Common.TestEntityConstants;

    [TestFixture]
    public class ImageServiceTests
    {
        private Mock<ICloudinaryService> cloudinaryMock;
        private IImageService imageService;

        [SetUp]
        public void Setup()
        {
            cloudinaryMock = new Mock<ICloudinaryService>();
            imageService = new ImageService(cloudinaryMock.Object);
        }

        private static Mock<IFormFile> CreateFileMock(string fileName = "image.jpg")
        {
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(f => f.FileName).Returns(fileName);
            fileMock.Setup(f => f.OpenReadStream()).Returns(Stream.Null);
            return fileMock;
        }

        private static RawUploadResult SuccessUploadResult(string url)
            => new RawUploadResult { Url = new Uri(url) };

        private static RawUploadResult FailedUploadResult(string message = "Upload error")
            => new RawUploadResult { Error = new Error { Message = message } };

        private static DeletionResult SuccessDeletionResult()
            => new DeletionResult();

        private static DeletionResult FailedDeletionResult(string message = "Delete error")
            => new DeletionResult { Error = new Error { Message = message } };

        // ── UploadImage ─────────────────────────────────────────────────────────

        [Test]
        public async Task UploadImage_ShouldReturnUrlOnSuccess()
        {
            cloudinaryMock
                .Setup(c => c.UploadAsync(It.IsAny<RawUploadParams>()))
                .ReturnsAsync(SuccessUploadResult(TEST_IMAGE_URL));

            var result = await imageService.UploadImage(CreateFileMock().Object, TEST_FOLDER, "test_image");

            result.Should().Be(TEST_IMAGE_URL);
        }

        [Test]
        public async Task UploadImage_ShouldCallCloudinaryWithCorrectFolder()
        {
            cloudinaryMock
                .Setup(c => c.UploadAsync(It.IsAny<RawUploadParams>()))
                .ReturnsAsync(SuccessUploadResult(TEST_IMAGE_URL));

            await imageService.UploadImage(CreateFileMock().Object, TEST_FOLDER, "image_name");

            cloudinaryMock.Verify(c => c.UploadAsync(
                It.Is<RawUploadParams>(p => p.Folder == TEST_FOLDER)),
                Times.Once);
        }

        [Test]
        public async Task UploadImage_ShouldThrowWhenUploadFails()
        {
            cloudinaryMock
                .Setup(c => c.UploadAsync(It.IsAny<RawUploadParams>()))
                .ReturnsAsync(FailedUploadResult());

            var act = async () => await imageService.UploadImage(CreateFileMock().Object, TEST_FOLDER, "test_image");

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        // ── EditImage ───────────────────────────────────────────────────────────

        [Test]
        public async Task EditImage_ShouldDeleteOldAndUploadNew()
        {
            cloudinaryMock
                .Setup(c => c.DestroyAsync(It.IsAny<DeletionParams>()))
                .ReturnsAsync(SuccessDeletionResult());
            cloudinaryMock
                .Setup(c => c.UploadAsync(It.IsAny<RawUploadParams>()))
                .ReturnsAsync(SuccessUploadResult(TEST_IMAGE_URL));

            var result = await imageService.EditImage(
                CreateFileMock().Object, "old_image_url", "image_name", TEST_FOLDER);

            result.Should().Be(TEST_IMAGE_URL);
            cloudinaryMock.Verify(c => c.DestroyAsync(It.IsAny<DeletionParams>()), Times.Once);
            cloudinaryMock.Verify(c => c.UploadAsync(It.IsAny<RawUploadParams>()), Times.Once);
        }

        [Test]
        public async Task EditImage_ShouldPassOldUrlToDeletion()
        {
            const string oldUrl = "old_image_public_id";
            cloudinaryMock
                .Setup(c => c.DestroyAsync(It.IsAny<DeletionParams>()))
                .ReturnsAsync(SuccessDeletionResult());
            cloudinaryMock
                .Setup(c => c.UploadAsync(It.IsAny<RawUploadParams>()))
                .ReturnsAsync(SuccessUploadResult(TEST_IMAGE_URL));

            await imageService.EditImage(CreateFileMock().Object, oldUrl, "image_name", TEST_FOLDER);

            cloudinaryMock.Verify(c => c.DestroyAsync(
                It.Is<DeletionParams>(p => p.PublicId == oldUrl)),
                Times.Once);
        }

        [Test]
        public async Task EditImage_ShouldThrowWhenDeletionFails()
        {
            cloudinaryMock
                .Setup(c => c.DestroyAsync(It.IsAny<DeletionParams>()))
                .ReturnsAsync(FailedDeletionResult());

            var act = async () => await imageService.EditImage(
                CreateFileMock().Object, "old_url", "name", TEST_FOLDER);

            await act.Should().ThrowAsync<InvalidOperationException>();
            cloudinaryMock.Verify(c => c.UploadAsync(It.IsAny<RawUploadParams>()), Times.Never);
        }

        [Test]
        public async Task EditImage_ShouldThrowWhenUploadFailsAfterDeletion()
        {
            cloudinaryMock
                .Setup(c => c.DestroyAsync(It.IsAny<DeletionParams>()))
                .ReturnsAsync(SuccessDeletionResult());
            cloudinaryMock
                .Setup(c => c.UploadAsync(It.IsAny<RawUploadParams>()))
                .ReturnsAsync(FailedUploadResult());

            var act = async () => await imageService.EditImage(
                CreateFileMock().Object, "old_url", "name", TEST_FOLDER);

            await act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Test]
        public async Task EditImage_ShouldNotUploadWhenDeletionFails()
        {
            cloudinaryMock
                .Setup(c => c.DestroyAsync(It.IsAny<DeletionParams>()))
                .ReturnsAsync(FailedDeletionResult());

            try
            {
                await imageService.EditImage(CreateFileMock().Object, "old_url", "name", TEST_FOLDER);
            }
            catch (InvalidOperationException) { }

            cloudinaryMock.Verify(c => c.UploadAsync(It.IsAny<RawUploadParams>()), Times.Never);
        }
    }
}
