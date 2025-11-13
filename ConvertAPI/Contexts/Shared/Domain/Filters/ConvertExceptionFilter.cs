using ConvertAPI.Contexts.Converts.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ConvertAPI.Contexts.Shared.Domain.Filters;

public class ConvertExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ConvertExceptionFilter> _logger;

    public ConvertExceptionFilter(ILogger<ConvertExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var (statusCode, message) = exception switch
        {
            InvalidKilogramsException => (StatusCodes.Status400BadRequest, exception.Message),
            _ => (StatusCodes.Status500InternalServerError, "An internal server error occurred. Please contact support.")
        };

        if (statusCode == StatusCodes.Status500InternalServerError)
            _logger.LogError(exception, "Unhandled exception occurred.");
        else
            _logger.LogWarning(exception, "Handled exception: {Message}", message);

        context.Result = new JsonResult(new { message }) { StatusCode = statusCode };
        context.ExceptionHandled = true;
    }
}