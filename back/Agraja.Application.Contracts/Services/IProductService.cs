using Agraja.Domain.Models;

namespace Agraja.Application.Contracts.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
    }
}
