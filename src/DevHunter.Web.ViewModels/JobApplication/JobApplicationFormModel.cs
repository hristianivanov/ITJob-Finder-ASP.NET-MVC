namespace DevHunter.Web.ViewModels.JobApplication
{
	using System.ComponentModel.DataAnnotations;

	using Microsoft.AspNetCore.Http;

	public class JobApplicationFormModel
	{
        public JobApplicationFormModel()
        {
	        this.Files = new List<IFormFile>();
        }

		[Required]
        public string CandidateName { get; set; } = null!;

		[Required]
		[EmailAddress]
		public string Email { get; set; } = null!;

		[Required]
		public string MotivationalLetter { get; set; } = null!;

		public List<IFormFile> Files { get; set; }
	}
}
