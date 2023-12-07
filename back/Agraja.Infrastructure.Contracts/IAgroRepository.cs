using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts.DTOs;

namespace Agraja.Infrastructure.Contracts
{
    public interface IAgroRepository
    {
        Task<List<Agro>> GetAll();
        Task<Agro> AddAgro(AgroAddRequestDto newAgro);
        Task<Agro> UpdateAgroById(int id, AgroUpdateRequestDto agroUpdate);
        Task<Agro> DeleteAgroById(int id);
        Task<Agro> GetAgroById(int id);


    }
}
