using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts.DTOs;

namespace Agraja.Application.Contracts.Services
{
    public interface IBoxxProductService
    {
        Task<List<BoxxProduct>> GetAll();

        //Task<AgroxProduct> AddNew(AgroxProductAddRequestDto agroxProdAddRequestDto);

        Task<List<Product>> GetProductByIdBox(int idbox);
    }
}
