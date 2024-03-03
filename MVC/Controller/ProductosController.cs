using Microsoft.AspNetCore.Mvc;
using WebApplication1.MVC.Model;
using WebApplication1.MVC.Service.ServiceInterface;

namespace WebApplication1.MVC.Controller
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
            if (id != producto.ProductoId)
            {
                return BadRequest(new { mensaje = "El ID proporcionado no coincide con el ID del producto." });
            }

            await _productoService.ActualizarProducto(producto);
            return Ok(new { mensaje = "Producto actualizado correctamente." });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var exito = await _productoService.EliminarProducto(id);
            if (!exito)
            {
                return NotFound(new { mensaje = "Producto no encontrado." });
            }

            return Ok(new { mensaje = "Producto eliminado correctamente." });
        }


        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var productos = await _productoService.ObtenerTodosProductos();
            return Ok(productos);
        }
    }
}
