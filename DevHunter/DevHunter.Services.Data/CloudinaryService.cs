using CloudinaryDotNet.Actions;

namespace DevHunter.Services.Data
{
	using CloudinaryDotNet;
	using DevHunter.Services.Data.Interfaces;

	public class CloudinaryService : ICloudinaryService
	{
		private readonly Cloudinary cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public async Task<RawUploadResult> UploadAsync(RawUploadParams parameters)
		{
			return await cloudinary.UploadAsync(parameters);
		}
	}
}
