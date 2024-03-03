using WebApplication1.MVC.Repository.RepositoryInterface;
using WebApplication1.MVC.Service.ServiceInterface;

namespace WebApplication1.MVC.Service
{
    public class MensajeService : IMensajeService


    {
        private readonly IMensajeRepository _mensajeRepository;

        public MensajeService(IMensajeRepository mensajeRepository)
        {
            _mensajeRepository = mensajeRepository;
        }

        public string ObtenerMensaje()
        {
            return _mensajeRepository.ObtenerMensaje();
        }
    }
}
