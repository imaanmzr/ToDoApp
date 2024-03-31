using System.Net;
using ToDoApp.Api.Models;
using ToDoApp.Application.Exceptions;

namespace ToDoApp.Api.Middlewares
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate next;

		public ExceptionMiddleware(RequestDelegate next)
		{
			this.next = next;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await next(httpContext);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(httpContext, ex);
			}
		}

		private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
		{
			HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
			CustomProblemDetails problem = new();

			switch (ex)
			{
				case BadRequestException badRequestException:
					statusCode = HttpStatusCode.BadRequest;
					problem = new CustomProblemDetails
					{
						Title = badRequestException.Message,
						Status = (int)statusCode,
						Detail = badRequestException.InnerException?.Message,
						Type = nameof(BadRequestException),
						Errors = badRequestException.ValidationErrors
					};

					break;

				case NotFoundException notFound:
					statusCode = HttpStatusCode.NotFound;
					problem = new CustomProblemDetails
					{
						Title = notFound.Message,
						Status = (int)statusCode,
						Detail = notFound.InnerException?.Message,
						Type = nameof(NotFoundException)
					};
					break;

				default:
					problem = new CustomProblemDetails
					{
						Title = ex.Message,
						Status = (int)statusCode,
						Type = nameof(HttpStatusCode.InternalServerError),
						Detail = ex.StackTrace
					};

					break;
			}
			httpContext.Response.StatusCode = (int)statusCode;
			await httpContext.Response.WriteAsJsonAsync(problem);
		}
	}
}
