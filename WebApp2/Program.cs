using Data;
using Service;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using WebApi1.Logging.FIleLogger;
using WebApi2.Middleweres.Logging;


var ConfBuilder = new ConfigurationBuilder();
ConfBuilder.SetBasePath(Directory.GetCurrentDirectory());
ConfBuilder.AddJsonFile("appsettings.json");
var config = ConfBuilder.Build();

string Usercon = config.GetConnectionString("UserConnection");
string CarCon = config.GetConnectionString("CarConnection");
string logPath = config.GetValue<string>("LogPath");

var builder = WebApplication.CreateBuilder(args);



builder.Host.ConfigureLogging(conf => 
{ 
    conf.ClearProviders();
    conf.AddFile(Path.Combine(Directory.GetCurrentDirectory(), logPath));
    conf.AddFilter("System", LogLevel.Warning);
    conf.AddFilter("LoggingConsoleApp.Program", LogLevel.Debug);

});



builder.Services.AddDbContext<RepositoryDBContext>(options => options.UseSqlite(Usercon));
builder.Services.AddDbContext<CarsContext>(opt=>opt.UseSqlite(CarCon));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IPayService, PayService>();
builder.Services.AddScoped<IExchangeService, ExchangeService>();
builder.Services.AddHttpClient("yoclient");

builder.Services.AddScoped<ICarService, CarService>();  // experiment

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddControllers();


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




