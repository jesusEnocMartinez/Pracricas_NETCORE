using WebApplication1.MVC.Model;
using WebApplication1.MVC.Repository.RepositoryInterface;
using WebApplication1.MVC.Service;
using Moq;
using Xunit;

namespace WebApplication1.Test.MVC.ServicesTest
{
    public class ProductoServiceTests
    {
        private readonly Mock<IProductoRepository> _productoRepositoryMock;
        private readonly ProductoService _productoService;

        public ProductoServiceTests()
        {
            
            _productoRepositoryMock = new Mock<IProductoRepository>();

            // Inicializa ProductoService pasando el mock como dependencia
            _productoService = new ProductoService(_productoRepositoryMock.Object);
        }

        [Fact]
        public async Task ObtenerProductoPorId_DebeRetornarProducto_CuandoProductoExiste()
        {
            
            var productoEsperado = new Producto { ProductoId = 1, Nombre = "Producto 1", Precio = 100 };
            _productoRepositoryMock.Setup(repo => repo.ObtenerProductoPorId(1))
                                   .ReturnsAsync(productoEsperado);

           
            var resultado = await _productoService.ObtenerProductoPorId(1);

            Assert.NotNull(resultado);
            Assert.Equal(productoEsperado.ProductoId, resultado.ProductoId);
            Assert.Equal(productoEsperado.Nombre, resultado.Nombre);
            Assert.Equal(productoEsperado.Precio, resultado.Precio);
        }
    }
}
