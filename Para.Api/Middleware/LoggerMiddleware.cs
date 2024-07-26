namespace Para.Api.Middleware
{
    public class LoggerMiddleware(RequestDelegate next, ILogger<LoggerMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path} {context.Request.QueryString}");

            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();
            logger.LogInformation($"Response: {context.Response.StatusCode} {context.Response.ContentType} {responseBodyText}");

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            await responseBody.CopyToAsync(originalBodyStream);
        }
    }
}
