using ToDoApp.Application.Models.Email;

namespace ToDoApp.Application.Contracts.Email
{
	public interface IEmailSender
	{
		Task<bool> SendEmail(EmailMessage email);
	}
}
