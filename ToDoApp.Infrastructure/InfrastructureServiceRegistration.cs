using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Contracts.Email;
using ToDoApp.Application.Contracts.Logging;
using ToDoApp.Application.Models.Email;
using ToDoApp.Infrastructure.EmailService;
using ToDoApp.Infrastructure.Logging;

namespace ToDoApp.Infrastructure
{
	public static class InfrastructureServiceRegistration
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
			services.AddTransient<IEmailSender, EmailSender>();
			services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
			return services;
		}
	}
}
