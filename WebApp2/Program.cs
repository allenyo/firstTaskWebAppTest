using Data;
using Domain.Interfaces;
using Service;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Domain.Models;
using FluentValidation.AspNetCore;
using Domain.Validation;
using WebApi1.Logging.FIleLogger;


var ConfBuilder = new ConfigurationBuilder();
ConfBuilder.SetBasePath(Directory.GetCurrentDirectory());
ConfBuilder.AddJsonFile("appsettings.json");
var config = ConfBuilder.Build();

string con = config.GetConnectionString("DefaultConnection");
string logPath = config.GetValue<string>("LogPath");

var builder = WebApplication.CreateBuilder(args);


builder.Logging.AddFile(Path.Combine(Directory.GetCurrentDirectory(), logPath ));



builder.Services.AddDbContext<RepositoryDBContext>(options => options.UseSqlite(con));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddControllers().AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssembly(typeof(UserValidator).Assembly);
    fv.DisableDataAnnotationsValidation = true;
    fv.AutomaticValidationEnabled = true;
});
builder.Services.AddScoped<IValidator<User>, UserValidator>();


var app = builder.Build();


app.Use(async (context, next) =>
{
#pragma warning disable CA2254 
    app.Logger.LogInformation($"Request Path: {context.Request.Path} Time: {DateTime.Now.ToLongTimeString()}");
#pragma warning restore CA2254

    await next.Invoke();

    app.Logger.LogInformation($"Response Status: {context.Response.StatusCode} Time: {DateTime.Now.ToLongTimeString()}");

    builder.Logging.Delete();
   
});

app.UseStatusCodePages(async statusCodeContext =>
{
    var response = statusCodeContext.HttpContext.Response;
    var path = statusCodeContext.HttpContext.Request.Path;

    await response.WriteAsync($"Error - {path}. Status Code - {response.StatusCode}");

});
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
   
});



app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("App Running");

});

app.Run();




