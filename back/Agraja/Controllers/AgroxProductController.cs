using Agraja.Application.Contracts.Services;
using Agraja.Application.Services;
using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Agraja_API.Controllers
{
    [Route("api/[controller]")]
    public class AgroxProductController : ControllerBase
    {
        private readonly IAgroxProductService _agroxProductService;

        public AgroxProductController(IAgroxProductService agroxProductService)
        {
            //Conexión entre Controller y Servicio
            _agroxProductService = agroxProductService;
        }
        //GET-->La petición puede llegar por URL
        [HttpGet]
        public async Task<List<AgroxProduct>> GetAll()
        {
            var agroxProducts = await _agroxProductService.GetAll();

            return agroxProducts;
        }


        [HttpGet]
        [Route("ProductsByAgro/{idagro}")]
        public async Task<List<Product>> GetProductByIdAgro(int idagro)
        {
            List<Product> products = await _agroxProductService.GetProductByIdAgro(idagro);

            return products;

        }

        [HttpGet]
        [Route("AgrosByProduct/{idproduct}")]
        public async Task<List<Agro>> GetAgrosByIdProduct(int idproduct)
        {
            List<Agro> agros = await _agroxProductService.GetAgrosByIdProduct(idproduct);

            return agros;
        }
    }
}
