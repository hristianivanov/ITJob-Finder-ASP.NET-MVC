namespace DevHunter.Services.Data.Interfaces
{
	using Microsoft.AspNetCore.Http;

	public interface IDocumentService
	{
		Task<string> UploadDocumentAsync(IFormFile file, string folder);
		Task AddAsync(string url, string applicationId);
	}
}
