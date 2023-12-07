using Agraja.Application.Contracts.Services;
using Agraja.Application.Services;
using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Agraja_API.Controllers
{
    [Route("api/[controller]")]//TODO
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            //Conexión entre Controller y Servicio
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<User>> GetAll()
        {
            var users = await _userService.GetAll();

            return users;

        }

        //[HttpGet]
        //[Route("{id}")]
        //public async Task<ActionResult<User>> GetUserById(int id)
        //{
        //    var userId = await _userService.GetUserById(id);

        //    if (userId == null)//TODOOOOOOOO
        //    {
        //        return BadRequest("No se ha podido recuperar el usuario");
        //    }
        //    else
        //    {
        //        return Ok(userId);
        //    }

        //}

        //[HttpPost]
        //[Route("AddUser")]//TODO: Decidir nombre ruta
        //public async Task<ActionResult> AddUser([FromBody] UserAddRequestDto newUser)//POST-->La petición tiene que llegar con un fichero JSON
        //{
        //    var userAdded = await _userService.AddUser(newUser);

        //    if (userAdded == null)
        //    {
        //        return BadRequest("El usuario no se ha podido registrar.");
        //    }
        //    else
        //    {
        //        return Ok(userAdded);
        //    }



        //}
    }
}
