using Agraja.Application.Contracts.Services;
using Agraja.Application.Services;
using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Agraja_API.Controllers
{
    [Route("api/[controller]")]
    public class BoxController : ControllerBase
    {
        private readonly IBoxService _boxService;

        public BoxController(IBoxService boxService)
        {
            //Conexión entre Controller y Servicio
            _boxService = boxService;
        }

        [HttpGet]
        [Route("AllBoxes")]
        public async Task<List<Box>> GetAll()
        {
            List<Box> boxes = await _boxService.GetAll();

            return boxes;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Box>> GetBoxById(int id)
        {
            Box boxId = await _boxService.GetBoxById(id);

            if (boxId == null)//TODOOOOOOOO
            {
                return BadRequest();
            }
            else
            {
                return Ok(boxId);
            }

        }

        [HttpPost]
        [Route("AddBox")]
        public async Task<ActionResult> AddBox([FromBody] BoxAddRequestDto newBox)//POST-->La petición tiene que llegar con un fichero JSON
        {
            Box boxAdded = await _boxService.AddBox(newBox);

            if (boxAdded == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(boxAdded);
            }
        }

        [HttpPut]
        [Route("UpdateBox/{id}")]
        public async Task<ActionResult> UpdateBoxById([FromRoute] int id, [FromBody, Required] BoxUpdateRequestDto boxUpdate)
        {
            Box boxUpdated = await _boxService.UpdateBoxById(id, boxUpdate);

            if (boxUpdated == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(boxUpdated);
            }
        }

        [HttpDelete]
        [Route("{boxId}")]
        public async Task<ActionResult> DeleteBoxById(int boxId)
        {
             await _boxService.DeleteBoxById(boxId);

            if (boxId < 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }
    }
}
