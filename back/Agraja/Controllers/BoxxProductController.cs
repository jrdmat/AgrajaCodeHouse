using Agraja.Application.Contracts.Services;
using Agraja.Application.Services;
using Agraja.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agraja_API.Controllers
{
    [Route("api/[controller]")]//TODO
    public class BoxxProductController : ControllerBase
    {
        private readonly IBoxxProductService _boxxProductService;

        public BoxxProductController(IBoxxProductService boxxProductService)
        {
            //Conexión entre Controller y Servicio
            _boxxProductService = boxxProductService;
        }
        //GET-->La petición puede llegar por URL
        [HttpGet]
        public async Task<List<BoxxProduct>> GetAll()
        {
            var boxxProducts = await _boxxProductService.GetAll();

            return boxxProducts;
        }

        [HttpGet]
        [Route("ProductsByBox/{idbox}")]
        public async Task<List<Product>> GetProductByIdBox(int idbox)
        {
            List<Product> product = await _boxxProductService.GetProductByIdBox(idbox);

            return product;


        }
    }
}

