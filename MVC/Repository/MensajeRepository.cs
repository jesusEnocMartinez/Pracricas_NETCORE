using WebApplication1.MVC.Repository.RepositoryInterface;

namespace WebApplication1.MVC.Repository
{
    public class MensajeRepository : IMensajeRepository
    {
        public string ObtenerMensaje()
        {
            return "Hola, ¡esto es mi primer endpoint en .NET CORE!";
        }
    }
}
