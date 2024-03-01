﻿using WebApplication1.Model;

namespace WebApplication1.Service.ServiceInterface
{
    public interface IProductoService
    {
        Task<Producto> CrearProducto(Producto producto);
        Task<Producto> ObtenerProductoPorId(int id);
        Task<Producto> ActualizarProducto(Producto producto);
        Task<bool> EliminarProducto(int id);
        Task<IEnumerable<Producto>> ObtenerTodosProductos();
    }
}
