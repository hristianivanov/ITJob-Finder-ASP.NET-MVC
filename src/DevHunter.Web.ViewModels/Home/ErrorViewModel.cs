namespace DevHunter.Web.ViewModels.Home
{
	public class ErrorViewModel
	{
		public string? RequestId { get; set; }

        public int StatusCode { get; set; }

        public string Error { get; set; } = null!;

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
	}
}