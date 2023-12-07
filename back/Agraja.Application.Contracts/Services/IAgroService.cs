using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts.DTOs;

namespace Agraja.Application.Contracts.Services
{
    public interface IAgroService
    {
        Task<List<Agro>> GetAll();
        Task<Agro> AddAgro(AgroAddRequestDto newAgro);
        Task<Agro> UpdateAgroById(int id, AgroUpdateRequestDto agroUpdate);
        Task<Agro> DeleteAgroById(int agroId);
        Task<Agro> GetAgroById(int id);
    }
}
