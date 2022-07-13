using api1Domain.Interfaces;
using api1Domain.Models;
using api1Domain.Validation;
using api1Service;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();
builder.Services.AddControllers().AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssembly(typeof(UserValidator).Assembly);
    fv.DisableDataAnnotationsValidation = true;
    fv.AutomaticValidationEnabled = true;
});
builder.Services.AddScoped<IValidator<User>, UserValidator>();

var app = builder.Build();


app.UseDeveloperExceptionPage();
app.UseSwagger();


app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "yo api");
    c.RoutePrefix = string.Empty;
});

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

});

app.Run();









