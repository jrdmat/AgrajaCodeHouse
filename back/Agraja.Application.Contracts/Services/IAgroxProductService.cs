using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts.DTOs;

namespace Agraja.Application.Contracts.Services
{
    public interface IAgroxProductService
    {
        Task<List<AgroxProduct>> GetAll();

        //Task<AgroxProduct> AddAgroxProduct(int productId);//TODOOOOO

        Task<List<Product>> GetProductByIdAgro(int idagro);

        Task<List<Agro>> GetAgrosByIdProduct(int idproduct);
    }
}
