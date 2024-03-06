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

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <param name="producto">El producto a crear.</param>
        /// <returns>El producto creado con el ID asignado.</returns>
        /// <response code="201">Retorna el producto recién creado.</response>
        /// <response code="400">Si el producto es nulo.</response>
        
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Producto producto)
        {
            var creado = await _productoService.CrearProducto(producto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.ProductoId }, creado);
        }


        /// <summary>
        /// Obtiene un producto por su ID.
        /// </summary>
        /// <param name="id">El ID del producto a obtener.</param>
        /// <returns>El producto solicitado.</returns>
        /// <response code="200">Si el producto fue encontrado.</response>
        /// <response code="404">Si el producto no fue encontrado.</response>
        
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var producto = await _productoService.ObtenerProductoPorId(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        /// <param name="id">El ID del producto a actualizar.</param>
        /// <param name="producto">Los datos actualizados del producto.</param>
        /// <returns>Un mensaje indicando que el producto fue actualizado correctamente.</returns>
        /// <response code="200">Si el producto fue actualizado exitosamente.</response>
        /// <response code="400">Si el ID del producto no coincide con el ID en los datos del producto.</response>
     
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

        /// <summary>
        /// Elimina un producto por su ID.
        /// </summary>
        /// <param name="id">El ID del producto a eliminar.</param>
        /// <returns>Un mensaje indicando que el producto fue eliminado correctamente.</returns>
        /// <response code="200">Si el producto fue eliminado exitosamente.</response>
        /// <response code="404">Si el producto no fue encontrado.</response>

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

        /// <summary>
        /// Obtiene todos los productos disponibles.
        /// </summary>
        /// <remarks>
        /// Este método de API devuelve una lista de todos los productos. 
        /// Puede ser usado para mostrar los productos en una interfaz de usuario o para otras operaciones de consulta.
        /// </remarks>
        /// <response code="200">Retorna una lista de productos si la operación es exitosa.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerTodos()
        {
            var productos = await _productoService.ObtenerTodosProductos();
            return Ok(productos);
        }
    }
}
