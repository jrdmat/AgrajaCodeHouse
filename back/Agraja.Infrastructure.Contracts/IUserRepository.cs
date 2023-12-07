using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts.DTOs;

namespace Agraja.Infrastructure.Contracts
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        //Task<User> AddUser(UserAddRequestDto userAddRequestDto);
        //Task<User> GetUserById(int id);

    }
}
