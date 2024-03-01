using WebApplication1.Repository.RepositoryInterface;

namespace WebApplication1.Repository
{
    public class MensajeRepository : IMensajeRepository
    {
        public string ObtenerMensaje()
        {
            return "Hola, ¡esto es mi primer endpoint en .NET CORE!";
        }
    }
}
