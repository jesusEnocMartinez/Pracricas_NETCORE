using WebApplication1.Model;

namespace WebApplication1.Repository.RepositoryInterface
{
    public interface IProductoRepository
    {
        Task<Producto> CrearProducto(Producto producto);
        Task<Producto> ObtenerProductoPorId(int id);
        Task<Producto> ActualizarProducto(Producto producto);
        Task<bool> EliminarProducto(int id);
        Task<IEnumerable<Producto>> ObtenerTodosProductos();
    }
}
