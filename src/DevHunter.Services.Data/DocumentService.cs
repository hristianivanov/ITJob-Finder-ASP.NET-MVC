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
        private static readonly HashSet<string> AllowedExtensions =
            new(StringComparer.OrdinalIgnoreCase) { ".pdf", ".doc", ".docx", ".txt", ".rtf" };

        private const long MaxFileSizeBytes = 10 * 1024 * 1024; // 10 MB

        private readonly DevHunterDbContext dbContext;
        private readonly ICloudinaryService cloudinaryService;

        public DocumentService(DevHunterDbContext dbContext, ICloudinaryService cloudinaryService)
        {
            this.dbContext = dbContext;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<string> UploadDocumentAsync(IFormFile file, string folder)
        {
            if (file.Length > MaxFileSizeBytes)
            {
                throw new InvalidOperationException("File size exceeds the 10 MB limit.");
            }

            string extension = Path.GetExtension(file.FileName);
            if (!AllowedExtensions.Contains(extension))
            {
                throw new InvalidOperationException(
                    $"File type '{extension}' is not allowed. Accepted types: {string.Join(", ", AllowedExtensions)}");
            }

            string safeFileName = Path.GetFileNameWithoutExtension(Guid.NewGuid().ToString()) + extension;

            await using var stream = file.OpenReadStream();

            var uploadParams = new RawUploadParams()
            {
                Folder = folder,
                PublicId = safeFileName,
                File = new FileDescription(safeFileName, stream),
            };

            var uploadResult = await cloudinaryService.UploadAsync(uploadParams);

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

        public async Task UploadAndSaveAsync(IFormFile file, string folder, string applicationId)
        {
            string url = await UploadDocumentAsync(file, folder);

            string publicId = Path.GetFileNameWithoutExtension(new Uri(url).Segments.Last());

            try
            {
                await AddAsync(url, applicationId);
            }
            catch
            {
                await cloudinaryService.DestroyAsync(new DeletionParams(publicId));
                throw;
            }
        }
    }
}
