using NumberConverter.Service;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Number Converter API", Version = "v1" });
});
builder.Services.AddSingleton<ConverterService>();

var app = builder.Build();

// Serve static files (wwwroot)
app.UseDefaultFiles();   // serves index.html by default
app.UseStaticFiles();

// Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Number Converter API V1");
    c.RoutePrefix = "swagger"; // Swagger will be at /swagger
});

// Optional: disable HTTPS locally
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

// Bind to dynamic port
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Urls.Add($"http://*:{port}");

app.Run();
