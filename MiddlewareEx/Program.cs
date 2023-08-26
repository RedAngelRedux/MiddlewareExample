/// </example_three>
/// Example of a chained middleware.  In this example we use app.Use(), which can 
/// forward the context to the next middleware in the chain, and/or terminate the
/// chaid as well
///
using MiddlewareEx.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<MiddlewareTwo>();

var app = builder.Build();

// middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello from Middleware 1. ");
    await next(context);
});

// middleware 2
app.UseMiddleware<MiddlewareTwo>();

// middleware 3
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello from middleware 3. ");
});
///
/// </example_three>


///// </example two>
///// Example of a chained middleware.  In this example we use app.Use(), which can 
///// forward the context to the next middleware in the chain, and/or terminate the
///// chaid as well
/////
//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//// middleware 1
//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//    await context.Response.WriteAsync("Hello from middleware 1. ");
//    await next(context);
//});

//// middleware 2
//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//    await context.Response.WriteAsync("Hello from middleware 2. ");
//    await next(context);
//});

//// middleware 3
//app.Run(async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("Hello from middleware 3");
//});
/////
///// </example two>

///// <example_one> 
///// Example of short-circuited Middleware.  In this case the second app.Run() will
///// never be called.
/////
//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//// middleware 1
//app.Run(async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("Hello from Middleware 1. ");
//});

//// middleware 2
///// <note>
///// This method is never called; it is short-circuited because previous middleware 
///// was a terminating middleware
///// </note>
//app.Run(async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("Hello from Middleware 2.");
//});
/////
///// </example_one>

app.Run();
