using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Models.Email;

namespace ToDoApp.Application.Contracts.Email
{
	public interface IEmailSender
	{
		Task<bool> SendEmail(EmailMessage email);
	}
}
