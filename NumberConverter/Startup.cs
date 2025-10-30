using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using NumberConverter.Service;
using Microsoft.AspNetCore.Builder;

namespace NumberConverter
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ConverterService>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Number Converter API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(WebApplication app)
        {
            // Serve static files
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Number Converter API V1");
                c.RoutePrefix = "swagger"; // Swagger at /swagger
            });

            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
