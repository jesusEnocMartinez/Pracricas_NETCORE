using Microsoft.AspNetCore.Mvc;
using WebApplication1.Service.ServiceInterface;

namespace WebApplication1.Controller
{
    [ApiController]
    [Route("api/v1")]
    public class MensajeController : ControllerBase
    {
        private readonly IMensajeService _mensajeService;

        public MensajeController(IMensajeService mensajeService)
        {
            _mensajeService = mensajeService;
        }

        [HttpGet("mensaje")]
        public IActionResult ObtenerMensaje()
        {
            var mensaje = _mensajeService.ObtenerMensaje();
            return Ok(new { mensaje = mensaje });
        }
    }
}
