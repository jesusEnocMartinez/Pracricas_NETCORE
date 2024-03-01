using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Service.ServiceInterface;

namespace WebApplication1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Producto producto)
        {
            var creado = await _productoService.CrearProducto(producto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.ProductoId }, creado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var producto = await _productoService.ObtenerProductoPorId(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Producto producto)
        {
            if (id != producto.ProductoId) return BadRequest();
            await _productoService.ActualizarProducto(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var exito = await _productoService.EliminarProducto(id);
            if (!exito) return NotFound();
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var productos = await _productoService.ObtenerTodosProductos();
            return Ok(productos);
        }
    }
}
