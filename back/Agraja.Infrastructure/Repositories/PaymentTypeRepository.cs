using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Agraja.Infrastructure.Repositories
{
    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        private readonly AgrajaDbContext _context;

        public PaymentTypeRepository(AgrajaDbContext dbcontext)
        {
            //Este método lo utilizamos para privatizar el contexto
            _context = dbcontext;
        }

        public async Task<List<PaymentType>> GetAll()
        {
            //Crear consulta LINQ
            List<PaymentType> payTypes = await _context.PaymentTypes.ToListAsync();

            return payTypes;
        }
    }
}
