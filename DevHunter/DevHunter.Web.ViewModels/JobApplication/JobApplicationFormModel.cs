namespace DevHunter.Web.ViewModels.JobApplication
{
	using Microsoft.AspNetCore.Http;

	public class JobApplicationFormModel
	{
        public JobApplicationFormModel()
        {
	        this.Files = new List<IFormFile>();
        }

        public string CandidateName { get; set; } = null!;

		public string Email { get; set; } = null!;

		public string MotivationalLetter { get; set; } = null!;

		public List<IFormFile> Files { get; set; }
	}
}
