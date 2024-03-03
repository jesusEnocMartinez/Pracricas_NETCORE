using Microsoft.OpenApi.Models;

namespace WebApplication1.Config
{
    public class ConfigServices 
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Agrega Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Documentacion de api Swagger", Version = "v1" });
            });
        }
    }

}
