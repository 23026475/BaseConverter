using Microsoft.AspNetCore.Builder;
using NumberConverter;


// Get the dynamic port (Heroku, Azure, etc.)
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";

// Build the app
var builder = WebApplication.CreateBuilder(args);

// Set the URLs before building the app
builder.WebHost.UseUrls($"http://*:{port}");

// Use Startup.cs to configure services
var startup = new Startup();
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Serve static files (wwwroot)
app.UseStaticFiles();

// Serve default files like index.html
app.UseDefaultFiles();

// Use Startup.cs to configure middleware (API, routing, etc.)
startup.Configure(app);

// Run the app
app.Run();
