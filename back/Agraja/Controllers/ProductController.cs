using Agraja.Application.Contracts.Services;
using Agraja.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agraja_API.Controllers
{
    [Route("api/[controller]")]//TODO
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            //Conexión entre Controller y Servicio
            _productService = productService;
        }

        [HttpGet]
        [Route("AllProducts")]
        public async Task<List<Product>> GetAll()
        {
            List<Product> products = await _productService.GetAll();

            return products;

        }

    }
}
