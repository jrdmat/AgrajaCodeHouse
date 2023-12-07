using Agraja.Application.Contracts.Services;
using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts;

namespace Agraja.Application.Services
{
    public class ProductService : IProductService
    {   //Conexión entre Service y Repository
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAll()
        {
            //El metodo nos devuelve los datos que queremos del Repository
            List<Product> products = await _productRepository.GetAll();

            return products;
        }
    }
}
