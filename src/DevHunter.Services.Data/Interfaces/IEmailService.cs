namespace DevHunter.Services.Data.Interfaces
{
	using Web.ViewModels.Home;

	public interface IEmailService
	{
		Task SendEmailAsync(FormMessageModel email);
	}
}
