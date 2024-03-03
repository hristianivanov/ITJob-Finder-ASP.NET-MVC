namespace DevHunter.Web.Infrastructure.Extensions
{
	public static class CloudinaryExtensions
	{
		/// <summary>
		///	Provides extension method for enhancing Cloudinary image URLs.
		/// </summary>
		/// <param name="imageUrl"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="quality"></param>
		/// <returns></returns>
		public static string EnhanceCloudinaryUrl(this string imageUrl, int width, string quality)
		{
			// Split the URL into base and version
			string[] urlParts = imageUrl.Split("/v");
			string baseUrl = urlParts[0];
			string versionPart = "/v" + urlParts[1];

			// Define the enhancement parameters
			string enhancements = $"f_auto,q_auto,w_{width},c_scale";

			// Combine the parts to create the enhanced URL
			string enhancedUrl = $"{baseUrl}/{enhancements}{versionPart}";

			return enhancedUrl;
		}
	}
}
