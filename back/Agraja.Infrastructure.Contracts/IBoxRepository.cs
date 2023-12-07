using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts.DTOs;

namespace Agraja.Infrastructure.Contracts
{
    public interface IBoxRepository
    {
        Task<List<Box>> GetAll();
        Task<Box> AddBox(BoxAddRequestDto newBox);
        Task<Box> UpdateBoxById(int id, BoxUpdateRequestDto boxUpdate);
        Task<Box> DeleteBoxById(int id);
        Task<Box> GetBoxById(int id);
    }
}
