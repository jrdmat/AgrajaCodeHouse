using Agraja.Application.Contracts.Services;
using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts;
using Agraja.Infrastructure.Contracts.DTOs;

namespace Agraja.Application.Services
{
    public class BoxxProductService : IBoxxProductService
    {   //Conexión entre Service y Repository
        private readonly IBoxxProductRepository _boxxProductRepository;

        public BoxxProductService(IBoxxProductRepository boxxProductRepository)
        {
            _boxxProductRepository = boxxProductRepository;
        }

        public async Task<List<BoxxProduct>> GetAll()
        {
            //El metodo nos devuelve los datos que queremos del Repository
            var boxxProducts = await _boxxProductRepository.GetAll();

            return boxxProducts;
        }

        public async Task<List<Product>> GetProductByIdBox(int idbox)
        {
            List<Product> product = await _boxxProductRepository.GetProductByIdBox(idbox);

            return product;

        }
    }
}
