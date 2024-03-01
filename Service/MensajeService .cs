using WebApplication1.Repository.RepositoryInterface;
using WebApplication1.Service.ServiceInterface;

namespace WebApplication1.Service
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
