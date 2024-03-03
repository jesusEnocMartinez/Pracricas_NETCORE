using Microsoft.EntityFrameworkCore;
using WebApplication1.MVC.Model;
using WebApplication1.MVC.Repository.RepositoryInterface;
using WebApplication1.Singleton.WebApplication1.Data;

namespace WebApplication1.MVC.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Producto> CrearProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<Producto> ObtenerProductoPorId(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<Producto> ActualizarProducto(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<bool> EliminarProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Producto>> ObtenerTodosProductos()
        {
            return await _context.Productos.ToListAsync();
        }
    }
}
