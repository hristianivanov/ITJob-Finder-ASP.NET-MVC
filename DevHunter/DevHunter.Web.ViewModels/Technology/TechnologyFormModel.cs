namespace DevHunter.Web.ViewModels.Technology
{
	using System.ComponentModel.DataAnnotations;

	using Microsoft.AspNetCore.Http;

	using Infrastructure.Extensions;

	using static Common.EntityValidationConstants.Technology;

	public class TechnologyFormModel
	{
		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;

		[DataType(DataType.Upload)]
		[Required(ErrorMessage = "Please select a file.")]
		[MaxFileSize(ImageMaxMegaBytesFileSize * 1024 * 1024)]
		[AllowedExtensions(new string[] { ".jpg", ".png" })]
		public IFormFile Image { get; set; } = null!;
		public string? DevelopmentId { get; set; }
	}
}
