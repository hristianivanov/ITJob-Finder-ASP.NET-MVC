namespace DevHunter.Services.Data.Interfaces
{
	using Microsoft.AspNetCore.Http;

	public interface IImageService
	{
		Task<string> UploadImage(IFormFile file, string folder, string fileName);
	}
}
