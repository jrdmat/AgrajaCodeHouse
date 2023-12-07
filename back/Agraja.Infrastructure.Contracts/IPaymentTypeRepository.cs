using Agraja.Domain.Models;

namespace Agraja.Infrastructure.Contracts
{
    public interface IPaymentTypeRepository
    {
        Task<List<PaymentType>> GetAll();
    }
}
