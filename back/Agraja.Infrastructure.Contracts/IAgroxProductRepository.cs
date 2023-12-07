using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts.DTOs;

namespace Agraja.Infrastructure.Contracts
{
    public interface IAgroxProductRepository
    {
        Task<List<AgroxProduct>> GetAll();

        Task<List<AgroxProduct>> AddAgroxProduct(int agroId, List<int> ProductIds);

        Task<List<Product>> GetProductByIdAgro(int idagro);

        Task<List<Agro>> GetAgrosByIdProduct(int idproduct);
    }
}
