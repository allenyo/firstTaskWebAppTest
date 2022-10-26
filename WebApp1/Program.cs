using api1Domain.Interfaces;
using api1Domain.Models;
using api1Domain.Validation;
using api1Service;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<RequestManager>();

builder.Services.AddTransient<ICarService, CarService>(); // eex

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();
builder.Services.AddScoped<HttpResponseMessage>();
builder.Services.AddHttpClient();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<User>, UserValidator>();

builder.Host.ConfigureLogging(conf =>
{
    conf.AddFilter("System", LogLevel.Warning);
    conf.AddFilter("LoggingConsoleApp.Program", LogLevel.Debug);
    conf.AddFilter("Microsoft", LogLevel.Warning);

});

var app = builder.Build();

app.UseStatusCodePages(async statusCodeContext =>
{
    var response = statusCodeContext.HttpContext.Response;
    var path = statusCodeContext.HttpContext.Request.Path;

   await response.WriteAsync($"Error - {path}. Status Code - {response.StatusCode}");


});
app.UseSwagger();


app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "yo api");
    c.RoutePrefix = string.Empty;
    c.DisplayRequestDuration();
    c.DisplayOperationId();
    
});

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

});

app.Run();









