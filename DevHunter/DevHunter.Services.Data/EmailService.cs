namespace DevHunter.Services.Data
{
	using MailKit.Net.Smtp;
	using MimeKit;

	using Common;
	using Interfaces;
	using Web.ViewModels.Home;

	public class EmailService : IEmailService
	{
		private readonly EmailConfig emailConfig;

		public EmailService(EmailConfig emailConfig)
		{
			this.emailConfig = emailConfig;
		}

		public async Task SendEmailAsync(FormMessageModel email)
		{
			var mailMessage = CreateEmailMessage(email);
			await SendAsync(mailMessage);
		}

		private MimeMessage CreateEmailMessage(FormMessageModel message)
		{
			var emailMessage = new MimeMessage();
			emailMessage.From.Add(new MailboxAddress(null, message.From));
			emailMessage.To.Add(new MailboxAddress(null, emailConfig.UserName));
			emailMessage.Subject = message.Subject;
			emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = $"{message.From}: {message.Content}" };

			return emailMessage;
		}
		private async Task SendAsync(MimeMessage mailMessage)
		{
			using var client = new SmtpClient();

			try
			{
				await client.ConnectAsync(emailConfig.SmtpServer, emailConfig.Port);
				client.AuthenticationMechanisms.Remove("XOAUTH2");
				await client.AuthenticateAsync(emailConfig.UserName, emailConfig.Password);
				await client.SendAsync(mailMessage);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				await client.DisconnectAsync(true);
				client.Dispose();
			}
		}
	}
}
