using Agraja.Domain.Models;

namespace Agraja.Application.Contracts.Services
{
    public interface IPaymentTypeService
    {
        Task<List<PaymentType>> GetAll();
    }
}
