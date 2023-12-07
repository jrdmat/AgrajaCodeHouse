using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts;
using Agraja.Infrastructure.Contracts.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Agraja.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AgrajaDbContext _context;

        public UserRepository(AgrajaDbContext dbcontext)
        {
            //Este método lo utilizamos para privatizar el contexto
            _context = dbcontext;
        }

        public async Task<List<User>> GetAll()
        {
            //TODO: SEGURAMENTE NO NECESARIO
            //Crear consulta LINQ
            var users = await _context.Users.ToListAsync();

            return users;
        }

        //public async Task<User> AddUser(UserAddRequestDto userAddRequestDto)
        //{
        //    User user = new User();
        //    user.UserName = userAddRequestDto.UserName;
        //    user.Password = userAddRequestDto.Password;
        //    user.IsAdmin = userAddRequestDto.IsAdmin;
        //    user.IsActive = userAddRequestDto.IsActive;

        //    var userAdded = await _context.Users.AddAsync(user);
        //    _context.SaveChanges();

        //    return userAdded.Entity;
        //}

        //public async Task<User> GetUserById(int id)
        //{
        //    var userReturned = _context.Users.Where(x => x.Id == id).FirstOrDefault();

        //    await _context.SaveChangesAsync();//TODOOO: Es necesario??

        //    return userReturned;
        //}
    }
}
