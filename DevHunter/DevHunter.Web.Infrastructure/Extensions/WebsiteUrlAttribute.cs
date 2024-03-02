namespace DevHunter.Web.Infrastructure.Extensions
{
	using System;
	using System.ComponentModel.DataAnnotations;

	public class WebsiteUrlAttribute : ValidationAttribute
	{
		public WebsiteUrlAttribute()
		{
			ErrorMessage = "The field {0} must be a valid website URL.";
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
			{
				return ValidationResult.Success!;
			}

			string url = value.ToString()!;

			if (Uri.TryCreate(url, UriKind.Absolute, out Uri result) 
			    && (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps))
			{
				return ValidationResult.Success!;
			}

			return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
		}
	}

}
