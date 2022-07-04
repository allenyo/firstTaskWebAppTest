using Data;
using Domain.Interfaces;
using Service;
using Microsoft.EntityFrameworkCore;
using System.Text;

var ConfBuilder = new ConfigurationBuilder();
ConfBuilder.SetBasePath(Directory.GetCurrentDirectory());
ConfBuilder.AddJsonFile("appsettings.json");
var config = ConfBuilder.Build();


string con = config.GetConnectionString("DefaultConnection");



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RepositoryDBContext>(options => options.UseSqlite(con));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddControllers();

var app = builder.Build();


app.UseDefaultFiles();
app.UseStaticFiles();

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




