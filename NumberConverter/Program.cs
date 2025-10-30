using NumberConverter.Service;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Number Converter API", Version = "v1" });
});
builder.Services.AddSingleton<ConverterService>();

var app = builder.Build();

// Enable Swagger for all environments
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Number Converter API V1");
    c.RoutePrefix = string.Empty;
});

// Optional: disable HTTPS for local testing
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

// Bind to dynamic HTTP port
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Urls.Add($"http://*:{port}");

app.Run();
