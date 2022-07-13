using Data;
using Domain.Interfaces;
using Service;
using Microsoft.EntityFrameworkCore;
using System.Text;
using FluentValidation;
using Domain.Models;
using FluentValidation.AspNetCore;
using Domain.Validation;

var ConfBuilder = new ConfigurationBuilder();
ConfBuilder.SetBasePath(Directory.GetCurrentDirectory());
ConfBuilder.AddJsonFile("appsettings.json");
var config = ConfBuilder.Build();


string con = config.GetConnectionString("DefaultConnection");



var builder = WebApplication.CreateBuilder(args);
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


app.UseDeveloperExceptionPage();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
   
});

app.MapGet("/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
        {
            var sb = new StringBuilder();
            var endpoints = endpointSources.SelectMany(es => es.Endpoints);
            foreach (var endpoint in endpoints)
            {
                sb.AppendLine(endpoint.DisplayName);

           
                if (endpoint is RouteEndpoint routeEndpoint)
                {
                    sb.AppendLine(routeEndpoint.RoutePattern.RawText);
                }

           
            }
            return sb.ToString();


        });

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("App Running");

});

app.Run();




