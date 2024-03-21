namespace DevHunter.Web.ViewModels.JobApplication
{
	public class JobApplicationViewModel
	{
        public JobApplicationViewModel()
        {
            this.DocumentsUrl =  new HashSet<DocumentViewModel>(); 
        }

        public string Id { get; set; } = null!;

		public string CandidateName { get; set; } = null!;

		public string Email { get; set; } = null!;

		public string MotivationalLetter { get; set; } = null!;

		public string JobPosition { get; set; } = null!;

        public ICollection<DocumentViewModel> DocumentsUrl { get; set; }
    }

	public class DocumentViewModel
	{
		public string DocumentName { get; set; } = null!;
		public string DocumentUrl { get; set; } = null!;

    }
}
