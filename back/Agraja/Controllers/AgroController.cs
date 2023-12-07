using Agraja.Application.Contracts.Services;
using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Agraja_API.Controllers
{
    [Route("api/[controller]")]
    public class AgroController : ControllerBase
    {
        private readonly IAgroService _agroService;

        public AgroController(IAgroService agroService) 
        {
            //Conexión entre Controller y Servicio
            _agroService = agroService;
        }

        //GET-->La petición puede llegar por URL
        [HttpGet]
        [Route("AllAgros")]
        public async Task<List<Agro>> GetAll() 
        {
            List<Agro> agros = await _agroService.GetAll();

            return agros;
        
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Agro>> GetAgroById(int id)
        {

            if (id < 0)
            {
                return BadRequest("No se ha podido recuperar el Agro");
            }
            else
            {
                Agro agroId = await _agroService.GetAgroById(id);
                return Ok(agroId);
            }

        }

        [HttpPost]
        [Route("AddAgro")]
        public async Task<ActionResult> AddAgro([FromBody] AgroAddRequestDto newAgro)//POST-->La petición tiene que llegar con un fichero JSON
        {
            Agro agroAdded = await _agroService.AddAgro(newAgro);

            if (agroAdded == null)
            {
                return BadRequest("El Agro nuevo no se ha podido guardar correctamente");
            }
            else
            {
                return Ok(agroAdded);
            } 
        }

        [HttpPut]
        [Route("UpdateAgro/{id}")]
        public async Task<ActionResult> UpdateAgroById([FromRoute] int id, [FromBody, Required] AgroUpdateRequestDto agroUpdate)
        {
            Agro agroUpdated = await _agroService.UpdateAgroById(id, agroUpdate);

            if (agroUpdated == null)
            {
                return BadRequest("El Agro no se ha podido modificar correctamete");
            }
            else
            {
                return Ok(agroUpdated);
            }
        }

        [HttpDelete]
        [Route("{agroId}")]
        public async Task<ActionResult> DeleteAgroById(int agroId)
        {
            //Si el agroId obtenido desde el Front es negativo enviar error
            if (agroId < 0)
            {
                return BadRequest();
            }
            else
            {
                await _agroService.DeleteAgroById(agroId);
                return Ok();
            }
        }

    }
}
