using Data;
using Domain.Interfaces;
using Service;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Domain.Models;
using FluentValidation.AspNetCore;
using Domain.Validation;
using WebApi1.Logging.FIleLogger;
using WebApi2.Middleweres.Logging;



var ConfBuilder = new ConfigurationBuilder();
ConfBuilder.SetBasePath(Directory.GetCurrentDirectory());
ConfBuilder.AddJsonFile("appsettings.json");
var config = ConfBuilder.Build();

string con = config.GetConnectionString("DefaultConnection");
string logPath = config.GetValue<string>("LogPath");

var builder = WebApplication.CreateBuilder(args);



builder.Host.ConfigureLogging(conf => 
{ 
    conf.ClearProviders();
    conf.AddFile(Path.Combine(Directory.GetCurrentDirectory(), logPath));
    conf.AddFilter("System", LogLevel.Warning);
    conf.AddFilter("LoggingConsoleApp.Program", LogLevel.Debug);

});



builder.Services.AddDbContext<RepositoryDBContext>(options => options.UseSqlite(con));
builder.Services.AddDbContext<carsContext>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddTransient<ICarService, CarService>();  // experiment

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<User>, UserValidator>();


var app = builder.Build();

app.UseLog(app);


app.UseStatusCodePages(async statusCodeContext =>
{
    var response = statusCodeContext.HttpContext.Response;
    var path = statusCodeContext.HttpContext.Request.Path;

    await response.WriteAsync($"Error - {path}. Status Code - {response.StatusCode}");

});

app.UseRouting();

app.UseEndpoints( endpoints =>
{
    endpoints.MapControllers();
  
});



app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("App Running....");

});


app.Run();




