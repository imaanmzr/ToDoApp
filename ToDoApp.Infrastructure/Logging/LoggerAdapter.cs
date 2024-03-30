using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Contracts.Logging;

namespace ToDoApp.Infrastructure.Logging
{
	public class LoggerAdapter<T> : IAppLogger<T>
	{
		private readonly ILogger<T> logger;

		public LoggerAdapter(ILoggerFactory loggerFactory)
		{
			this.logger = loggerFactory.CreateLogger<T>();
		}
		public void LogInformation(string message, params object[] args)
		{
			logger.LogInformation(message, args);
		}

		public void LogWarning(string message, params object[] args)
		{
			logger.LogWarning(message, args);
		}
	}
}
