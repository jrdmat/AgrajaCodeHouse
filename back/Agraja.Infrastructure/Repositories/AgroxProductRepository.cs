using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts;
using Agraja.Infrastructure.Contracts.DTOs;
using Microsoft.EntityFrameworkCore;
using System;

namespace Agraja.Infrastructure.Repositories
{
    public class AgroxProductRepository : IAgroxProductRepository
    {
        private readonly AgrajaDbContext _context;

        public AgroxProductRepository(AgrajaDbContext dbcontext)
        {
            //Este método lo utilizamos para privatizar el contexto
            _context = dbcontext;
        }


        public async Task<List<AgroxProduct>> GetAll()
        {
            //Crear consulta LINQ
            List<AgroxProduct> agroxProducts = await _context.AgroxProducts.ToListAsync();

            return agroxProducts;
        }
        public async Task<List<AgroxProduct>> AddAgroxProduct(int agroId, List<int> ProductIds)
        {
            //Método llamado desde AgroRepository
            
            List<AgroxProduct> arrAgroxProducts = new List<AgroxProduct>();

            //Por cada ProductId en el array de ProductIds crear un nuevo AgroxProduct y añadirlo a la bd
            foreach (int productId in ProductIds) 
            {
                AgroxProduct agroxProduct = new AgroxProduct();
                agroxProduct.ProductId = productId;
                agroxProduct.AgroId = agroId;

                var agroxProductAdded = await _context.AgroxProducts.AddAsync(agroxProduct);
                arrAgroxProducts.Add(agroxProductAdded.Entity);
            }

            _context.SaveChanges();

            return arrAgroxProducts;
        }

        public async Task<List<Product>> GetProductByIdAgro(int idagro)
        {    
            //Consulta para la obtención de los Productos a partir del Id del Agro
            List<Product> productByIdAgro = await (from ap in _context.AgroxProducts
                                             join p in _context.Products on ap.ProductId equals p.Id
                                             where ap.AgroId == idagro
                                             select p).ToListAsync();

            return productByIdAgro;
        }

        public async Task<List<Agro>> GetAgrosByIdProduct(int idproduct)
        {
            //Consulta para la obtención de los Agros a partir del Id del Producto
            List<Agro> agroByProductId = await (from ap in _context.AgroxProducts
                                         join a in _context.Agros on ap.AgroId equals a.Id
                                         where ap.ProductId == idproduct
                                         select a).ToListAsync();

            return agroByProductId;

        }
    }
}
