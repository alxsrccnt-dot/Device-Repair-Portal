using Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace JobMonitoringApi.Infrastructure;

public class GlobalExceptionHandler : IExceptionHandler
{
	private readonly Dictionary<Type, Func<HttpContext, Exception, Task>> _exceptionHandlers =
		new()
		{
			{ typeof(UnauthorizedAccessException), HandleUnauthorizedAccessExceptionAsync },
			{ typeof(ForbiddenException), HandleForbiddenAccessExceptionAsync },
			{ typeof(ValidationException), HandleInvalidExceptionAsync },
			{ typeof(NotFoundException), HandleNotFoundExceptionAsync }
		};

	public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
	{
		var exceptionType = exception.GetType();
		if (_exceptionHandlers.TryGetValue(exceptionType, out var handler))
		{
			await handler(httpContext, exception);
			return true;
		}

		await HandleUnexpectedException(httpContext, exception);
		return true;
	}

	private static async Task HandleUnauthorizedAccessExceptionAsync(HttpContext httpContext, Exception exception)
	{
		httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
		await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
		{
			Title = "The request is unauthorized.",
			Status = StatusCodes.Status401Unauthorized
		});
	}

	private static async Task HandleForbiddenAccessExceptionAsync(HttpContext httpContext, Exception exception)
	{
		httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
		await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
		{
			Title = "The request is forbidden.",
			Status = StatusCodes.Status403Forbidden
		});
	}

	private static async Task HandleInvalidExceptionAsync(HttpContext httpContext, Exception exception)
	{
		var exceptionDetails = exception as ValidationException;

		var exceptionMessageBuilder = new StringBuilder();
		foreach (var error in exceptionDetails!.Errors)
			exceptionMessageBuilder.AppendLine(error);

		httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
		await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
		{
			Title = "The specified resourses was not found.",
			Status = StatusCodes.Status400BadRequest,
			Detail = exceptionMessageBuilder.ToString()
		});
	}

	private static async Task HandleNotFoundExceptionAsync(HttpContext httpContext, Exception exception)
	{
		var exceptionDetails = exception as NotFoundException;

		httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
		await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
		{
			Title = "The specified resourses was not found.",
			Status = StatusCodes.Status404NotFound,
			Detail = exceptionDetails!.Message
		});
	}

	private static async Task HandleUnexpectedException(HttpContext httpContext, Exception exception)
	{
		httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
		httpContext.Response.ContentType = "application/json";
		await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
		{
			Title = "An Unexpected error occurred.",
			Status = StatusCodes.Status500InternalServerError,
			Detail = exception.Message
		});
	}
} 