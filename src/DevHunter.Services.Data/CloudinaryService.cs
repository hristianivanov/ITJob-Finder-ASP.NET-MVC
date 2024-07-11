namespace DevHunter.Services.Data
{
	using CloudinaryDotNet;
	using CloudinaryDotNet.Actions;

	using Interfaces;

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

		public async Task<DeletionResult> DestroyAsync(DeletionParams deleteParams)
		{
			return await cloudinary.DestroyAsync(deleteParams);
		}
	}
}
