using System.Text.Json;

namespace PartyTracker.Api.Middleware;

public class LoggerMiddleware
{
    private readonly RequestDelegate _request;
    private readonly ILogger _logger;

    public LoggerMiddleware(RequestDelegate request, ILogger<LoggerMiddleware> logger)
    {
        _request = request;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _request(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                JsonSerializer.Serialize(
                    new
                    {
                        message = ex.Message,
                        stackTrace = ex.StackTrace,
                        innerException = ex.InnerException
                    }
                )
            );
            context.Response.StatusCode = 500;

            var error = new
            {
                ex.Message
            };
            await context.Response.WriteAsJsonAsync(error);
        }
    }
}

