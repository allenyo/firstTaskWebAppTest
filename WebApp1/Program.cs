using api1Domain.Validation;
using api1Service;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<RequestManager>();
builder.Services.AddScoped<IPayService, PayService>();
builder.Services.AddScoped<IExchangeService, ExchangeService>();

builder.Services.AddScoped<ICarService, CarService>();

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<HttpResponseMessage>();
builder.Services.AddHttpClient();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddSwaggerGenNewtonsoftSupport();

builder.Logging.AddFilter("System", LogLevel.Warning).AddFilter("LoggingConsoleApp.Program", LogLevel.Debug).AddFilter("Microsoft", LogLevel.Warning);

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


app.MapControllers();

app.Run();









