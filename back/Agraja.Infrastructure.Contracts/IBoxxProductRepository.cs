using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts.DTOs;

namespace Agraja.Infrastructure.Contracts
{
    public interface IBoxxProductRepository
    {
        Task<List<BoxxProduct>> GetAll();
        Task<List<BoxxProduct>> AddBoxxProduct(int agroId, List<int> ProductIds);
        Task<List<Product>> GetProductByIdBox(int idbox);
    }
}
