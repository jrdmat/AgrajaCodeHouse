using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts.DTOs;

namespace Agraja.Application.Contracts.Services
{
    public interface IBoxService
    {
        Task<List<Box>> GetAll();
        Task<Box> AddBox(BoxAddRequestDto newBox);
        Task<Box> UpdateBoxById(int id, BoxUpdateRequestDto boxUpdate);
        Task<Box> DeleteBoxById(int boxId);
        Task<Box> GetBoxById(int id);
    }
}
