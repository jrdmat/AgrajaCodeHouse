using Agraja.Application.Contracts.Services;
using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts;

namespace Agraja.Application.Services
{
    public class PaymentTypeService : IPaymentTypeService
    {
        //Conexión entre Service y Repository
        private readonly IPaymentTypeRepository _payTypeRepository;

        public PaymentTypeService(IPaymentTypeRepository payTypeRepository)
        {
            _payTypeRepository = payTypeRepository;
        }

        public async Task<List<PaymentType>> GetAll()
        {
            //El metodo nos devuelve los datos que queremos del Repository
            List<PaymentType> payTypes = await _payTypeRepository.GetAll();

            return payTypes;
        }
    }
}
