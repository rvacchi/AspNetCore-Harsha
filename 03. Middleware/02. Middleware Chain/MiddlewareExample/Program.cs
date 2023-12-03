var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//middlware 1
app.Use(async ( HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Hello");
    await next(context);
});

//middleware 2
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync(" Hello again");
    //await next(context);
});



//middleware 3
app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync(" Hello again 2");
});

//app.Run(async (HttpContext context) => {
//    await context.Response.WriteAsync(text: "test");
//});

app.Run();
