using WebApplication1.MVC.Repository.RepositoryInterface;
using WebApplication1.MVC.Repository;
using WebApplication1.MVC.Service.ServiceInterface;
using WebApplication1.MVC.Service;
/// <summary>
/// Configura los servicios de la aplicación.
/// </summary>
namespace WebApplication1.Config
{
    public static class ServicesConfiguration
    {
        /// <summary>
        /// Agrega servicios específicos de la aplicación al contenedor de servicios.
        /// </summary>
        /// <param name="services">El <see cref="IServiceCollection"/> al cual se añadirán los servicios.</param>
        /// <returns>El <see cref="IServiceCollection"/> con los servicios añadidos.</returns>
        /// <remarks>
        /// Este método extiende IServiceCollection para incluir la configuración de servicios específicos,
        /// como servicios de mensajería y productos, permitiendo una configuración centralizada y modular de los servicios utilizados en la aplicación.
        /// </remarks>
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

