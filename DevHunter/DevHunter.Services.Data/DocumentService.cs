namespace DevHunter.Services.Data
{
	using Microsoft.AspNetCore.Http;

	using CloudinaryDotNet;
	using CloudinaryDotNet.Actions;

	using DevHunter.Data;
	using DevHunter.Data.Models;

	using Interfaces;

	public class DocumentService : IDocumentService
	{
		private readonly Cloudinary cloudinary;
		private readonly DevHunterDbContext dbContext;

		public DocumentService(Cloudinary cloudinary, DevHunterDbContext dbContext)
		{
			this.cloudinary = cloudinary;
			this.dbContext = dbContext;
		}

		public async Task<string> UploadDocumentAsync(IFormFile file, string folder)
		{
			await using var stream = file.OpenReadStream();

			var uploadParams = new RawUploadParams()
			{
				Folder = folder,
				PublicId = file.FileName,
				File = new FileDescription(file.FileName, stream),
			};

			var uploadResult = await cloudinary.UploadAsync(uploadParams);

			if (uploadResult.Error != null)
			{
				throw new InvalidOperationException(uploadResult.Error.Message);
			}

			return uploadResult.SecureUrl.ToString();
		}

		public async Task AddAsync(string url, string applicationId)
		{
			ApplicationDocument document = new ApplicationDocument()
			{
				DocumentUrl = url,
				JobApplicationId = Guid.Parse(applicationId),
			};
			await this.dbContext.ApplicationDocuments.AddAsync(document);
			await this.dbContext.SaveChangesAsync();
		}
	}
}
