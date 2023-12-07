using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Agraja.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AgrajaDbContext _context;

        public ProductRepository(AgrajaDbContext dbcontext)
        {
            //Este método lo utilizamos para privatizar el contexto
            _context = dbcontext;
        }

        public async Task<List<Product>> GetAll()
        {
            //Crear consulta LINQ
            List<Product> products = await _context.Products.ToListAsync();

            return products;
        }

        
    }
}
