using Agraja.Application.Contracts.Services;
using Agraja.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agraja_API.Controllers
{
    [Route("api/[controller]")]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IPaymentTypeService _payTypeService;

        public PaymentTypeController(IPaymentTypeService payTypeService)
        {
            //Conexión entre Controller y Servicio
            _payTypeService = payTypeService;
        }

        [HttpGet]
        [Route("AllPaymentTypes")]
        public async Task<List<PaymentType>> GetAll()
        {
            List<PaymentType> payTypes = await _payTypeService.GetAll();

            return payTypes;
        }

    }
}
