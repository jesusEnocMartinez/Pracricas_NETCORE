﻿using WebApplication1.Model;
using WebApplication1.Repository.RepositoryInterface;
using WebApplication1.Service.ServiceInterface;

namespace WebApplication1.Service
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public Task<Producto> CrearProducto(Producto producto) => _productoRepository.CrearProducto(producto);

        public Task<Producto> ObtenerProductoPorId(int id) => _productoRepository.ObtenerProductoPorId(id);

        public Task<Producto> ActualizarProducto(Producto producto) => _productoRepository.ActualizarProducto(producto);

        public Task<bool> EliminarProducto(int id) => _productoRepository.EliminarProducto(id);

        public Task<IEnumerable<Producto>> ObtenerTodosProductos() => _productoRepository.ObtenerTodosProductos();
    }
}
