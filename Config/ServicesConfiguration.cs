using WebApplication1.MVC.Repository.RepositoryInterface;
using WebApplication1.MVC.Repository;
using WebApplication1.MVC.Service.ServiceInterface;
using WebApplication1.MVC.Service;

namespace WebApplication1.Config
{
    public static class ServicesConfiguration
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IMensajeService, MensajeService>();
            services.AddScoped<IMensajeRepository, MensajeRepository>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
      
            return services;
        }
    }
}

