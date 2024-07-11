namespace DevHunter.Data.Models.Complex
{
	using Microsoft.EntityFrameworkCore;

	[Owned]
	public class ImageData
	{
		public string OriginalFileName { get; set; } = null!;
		public string OriginalType { get; set; } = null!;
		public byte[] OriginalContent { get; set; } = null!;
		public byte[] ThumbnailContent { get; set; } = null!;
	}
}
