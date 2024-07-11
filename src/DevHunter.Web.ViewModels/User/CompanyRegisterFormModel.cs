namespace DevHunter.Web.ViewModels.User
{
	using System.ComponentModel.DataAnnotations;

	using Microsoft.AspNetCore.Http;

	using Infrastructure.Extensions;
	
	using static Common.EntityValidationConstants.Company;

	public class CompanyRegisterFormModel : RegisterFormModel
	{
		[Required]
		[StringLength(NameMaxLength,MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;

		[WebsiteUrl(ErrorMessage = "Please enter a valid website URL.")]
		public string? WebsiteUrl { get; set; }

		[DataType(DataType.Upload)]
		[Required(ErrorMessage = "Please select a file.")]
		[MaxFileSize(ImageMaxMegaBytesFileSize * 1024 * 1024)]
		[AllowedExtensions(new string[] { ".jpg", ".png" })]
		public IFormFile Image { get; set; } = null!;
	}
}
