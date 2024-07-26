using System.Text.Json;

namespace Para.Api.Middleware;


public class HeartbeatMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/heartbeat"))
        {
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync(JsonSerializer.Serialize("WriteAsync !"));
            return;
        }

        await next.Invoke(context);
    }
    
}