namespace MiddlewareEx.Middleware
{
    public class MiddlewareTwo : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Start of MiddlewareTwo. ");
            await next(context);
            await context.Response.WriteAsync("End of MiddlewareTwo. ");
        }
    }
}
