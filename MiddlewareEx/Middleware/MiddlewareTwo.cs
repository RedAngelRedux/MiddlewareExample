namespace MiddlewareEx.Middleware
{
    public class MiddlewareTwo : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Start of MiddlewareTwo.\n");
            await next(context);
            await context.Response.WriteAsync("End of MiddlewareTwo.\n");
        }
    }

    public static class MiddlewareTowExtension
    {
        public static IApplicationBuilder UseMiddlewareTwo(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MiddlewareTwo>();
        }
    }
}
