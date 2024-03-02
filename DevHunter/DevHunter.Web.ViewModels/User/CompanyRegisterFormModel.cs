namespace DevHunter.Web.ViewModels.User
{
	using System.ComponentModel.DataAnnotations;

	using Microsoft.AspNetCore.Http;

	using Infrastructure.Extensions;
	
	using static Common.EntityValidationConstants.Company;

	public class CompanyRegisterFormModel
	{
		public string Email { get; set; } = null!;

		public string Password { get; set; } = null!;

		public string Name { get; set; } = null!;

		public IFormFile Image { get; set; } = null!;
	}
}
