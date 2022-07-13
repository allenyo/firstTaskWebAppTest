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

var builder = WebApplication.CreateBuilder(args);


builder.Logging.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "Logging//FileLogger//log.txt"));


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
    app.Logger.LogInformation($"Request Path: {context.Request.Path} Time: {DateTime.Now.ToLongTimeString()}");

    await next.Invoke();

    app.Logger.LogInformation($"Response Status: {context.Response.StatusCode} Time: {DateTime.Now.ToLongTimeString()}");

});

app.UseDeveloperExceptionPage();
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




