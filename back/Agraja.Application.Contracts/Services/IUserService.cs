using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts.DTOs;

namespace Agraja.Application.Contracts.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        //Task<User> AddUser(UserAddRequestDto userAddRequestDto);
        //Task<User> GetUserById(int id);
    }
}
