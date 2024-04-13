namespace DevHunter.Services.Mocks
{
	using Microsoft.AspNetCore.Http;
	using Moq;

	using Data.Interfaces;

	using static Common.TestEntityConstants;

	public class ImageServiceMock
	{
		public static IImageService Instance
		{
			get
			{
				var imageServiceMock = new Mock<IImageService>();

				imageServiceMock.Setup(s => s.UploadImage(It.IsAny<IFormFile>(), It.IsAny<string>(), It.IsAny<string>()))
					.ReturnsAsync(TEST_IMAGE_URL);

				return imageServiceMock.Object;
			}
		}
	}
}
