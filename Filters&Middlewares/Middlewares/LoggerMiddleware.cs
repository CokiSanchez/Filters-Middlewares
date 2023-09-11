namespace Filters_Middlewares.Middlewares;

public class LoggerMiddleware : IMiddleware
{
    private readonly ILogger<LoggerMiddleware> _logger;

    public LoggerMiddleware(ILogger<LoggerMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        _logger.LogInformation("Incoming request: {verb}{path}", context.Request.Method, context.Request.Path);

        await next(context);

        _logger.LogInformation("Outgoing response: {status}", context.Response.StatusCode);
    }
}
