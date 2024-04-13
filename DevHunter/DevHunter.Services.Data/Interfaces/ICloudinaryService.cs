namespace DevHunter.Services.Data.Interfaces
{
	using CloudinaryDotNet.Actions;

	public interface ICloudinaryService
	{
		Task<RawUploadResult> UploadAsync(RawUploadParams parameters);
	}
}
