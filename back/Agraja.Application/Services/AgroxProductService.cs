using Agraja.Application.Contracts.Services;
using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts;
using Agraja.Infrastructure.Contracts.DTOs;

namespace Agraja.Application.Services
{
    public class AgroxProductService : IAgroxProductService
    {   //Conexión entre Service y Repository
        private readonly IAgroxProductRepository _agroxProductRepository;

        public AgroxProductService(IAgroxProductRepository agroxProductRepository)
        {
            _agroxProductRepository = agroxProductRepository;
        }


        public async Task<List<AgroxProduct>> GetAll()
        {
            //El metodo nos devuelve los datos que queremos del Repository
            List<AgroxProduct> agroxProducts = await _agroxProductRepository.GetAll();

            return agroxProducts;
        }

        public async Task<List<Product>> GetProductByIdAgro(int idagro)
        {
            List<Product> products = await _agroxProductRepository.GetProductByIdAgro(idagro);

            return products;

        }

        public async Task<List<Agro>> GetAgrosByIdProduct(int idproduct)
        {
            List<Agro> agros = await _agroxProductRepository.GetAgrosByIdProduct(idproduct);

            return agros;
        }
    }
}
