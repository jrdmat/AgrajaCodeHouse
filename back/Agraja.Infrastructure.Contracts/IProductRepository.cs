using Agraja.Domain.Models;

namespace Agraja.Infrastructure.Contracts
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
    }
}
