namespace DevHunter.Web.Infrastructure.Extensions
{
	using System.ComponentModel.DataAnnotations;

	using Microsoft.AspNetCore.Http;

	public class MaxFileSizeAttribute : ValidationAttribute
	{
		private readonly int maxFileSize;

		public MaxFileSizeAttribute(int maxFileSize)
		{
			this.maxFileSize = maxFileSize;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var file = value as IFormFile;

			if (file != null)
			{
				if (file.Length > maxFileSize)
				{
					return new ValidationResult(GetErrorMessage());
				}
			}

			return ValidationResult.Success!;
		}

		public string GetErrorMessage()
		{
			double megabytes = (double)maxFileSize / (1024 * 1024);
			return $"Maximum allowed file size is {megabytes} MB.";
		}
	}
}
