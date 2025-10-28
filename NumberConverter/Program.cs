using NumberConverter.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ConverterService>();

var app = builder.Build();

// Enable Swagger UI at root for all environments
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Number Converter API V1");
    c.RoutePrefix = string.Empty; // Swagger is served at "/"
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Bind to dynamic PORT for Railway
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Urls.Add($"http://*:{port}");

app.Run();
