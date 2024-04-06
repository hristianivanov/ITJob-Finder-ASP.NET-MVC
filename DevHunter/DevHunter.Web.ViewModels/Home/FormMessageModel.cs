namespace DevHunter.Web.ViewModels.Home
{
	using System.ComponentModel.DataAnnotations;

	public  class FormMessageModel
	{
		[Required]
		public string From { get; set; } = null!;
		[Required]
		public string Subject { get; set; } = null!;
		[Required]
		public string Content { get; set; } = null!;
		[Required]
		public string Name { get; set; } = null!;
	}
}
