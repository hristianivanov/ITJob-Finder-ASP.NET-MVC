namespace DevHunter.Services.Data
{
    using Microsoft.AspNetCore.Http;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;

    using Interfaces;

    public class ImageService : IImageService
    {
        private readonly ICloudinaryService cloudinaryService;

        public ImageService(ICloudinaryService cloudinaryService)
        {
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<string> UploadImage(IFormFile file, string folder, string fileName)
        {
            await using var stream = file.OpenReadStream();

            var uploadParams = new ImageUploadParams()
            {
                Folder = folder,
                PublicId = fileName,
                File = new FileDescription(fileName, stream),
            };

            var uploadResult = await cloudinaryService.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
            {
                throw new InvalidOperationException(uploadResult.Error.Message);
            }

            return uploadResult.Url.ToString();
        }

        public async Task<string> EditImage(IFormFile file, string oldImageUrl, string fileName, string folder)
        {
            await using var stream = file.OpenReadStream();

            var uploadParams = new ImageUploadParams()
            {
                Folder = folder,
                PublicId = fileName,
                File = new FileDescription(fileName, stream)
            };

            var deletionResult = await this.DeletePhotoAsync(oldImageUrl);

            if (deletionResult.Error != null)
            {
                throw new InvalidOperationException(deletionResult.Error.Message);
            }

            var uploadResult = await cloudinaryService.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
            {
                throw new InvalidOperationException(uploadResult.Error.Message);
            }

            return uploadResult.Url.ToString();
        }

        private async Task<DeletionResult> DeletePhotoAsync(string id)
        {
            var deleteParams = new DeletionParams(id);

            var result = await this.cloudinaryService.DestroyAsync(deleteParams);

            return result;
        }

    }


}
