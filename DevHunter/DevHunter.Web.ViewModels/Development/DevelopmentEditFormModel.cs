namespace DevHunter.Web.ViewModels.Development
{
	using System.ComponentModel.DataAnnotations;

	using Microsoft.AspNetCore.Http;

	using Infrastructure.Extensions;

	using static Common.EntityValidationConstants.Development;

	public class DevelopmentEditFormModel
	{
		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;

		[DataType(DataType.Upload)]
		[MaxFileSize(ImageMaxMegaBytesFileSize * 1024 * 1024)]
		[AllowedExtensions(new string[] { ".jpg", ".png" })]
		public IFormFile? Image { get; set; }

		public string? ImageUrl { get; set; }
	}
}
