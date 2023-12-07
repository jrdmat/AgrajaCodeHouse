using Agraja.Application.Contracts.Services;
using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts;
using Agraja.Infrastructure.Contracts.DTOs;

namespace Agraja.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //public async Task<User> AddUser(UserAddRequestDto userAddRequestDto)
        //{
        //    User userAdded = null;

        //    if (userAddRequestDto != null)
        //    {
        //        userAdded = await _userRepository.AddUser(userAddRequestDto);
        //    }

        //    return userAdded;
        //}

        public async Task<List<User>> GetAll()
        {
            //El metodo nos devuelve los datos que queremos del Repository
            var users = await _userRepository.GetAll();

            return users;
        }

        //public async Task<User> GetUserById(int id)
        //{

        //    var userId = await _userRepository.GetUserById(id);

        //    return userId;

        //}
    }
}
