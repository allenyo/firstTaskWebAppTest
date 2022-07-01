

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();



app.UseDefaultFiles();
app.UseStaticFiles();

app.UseDeveloperExceptionPage();
app.UseRouting();
app.UseSwagger();


app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "yo api");
    c.RoutePrefix = string.Empty;
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

});

app.Run();









