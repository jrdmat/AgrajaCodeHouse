using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts;
using Agraja.Infrastructure.Contracts.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Agraja.Infrastructure.Repositories
{
    public class BoxxProductRepository : IBoxxProductRepository
    {
        private readonly AgrajaDbContext _context;

        public BoxxProductRepository(AgrajaDbContext dbcontext)
        {
            //Este método lo utilizamos para privatizar el contexto
            _context = dbcontext;
        }



        public async Task<List<BoxxProduct>> GetAll()
        {
            //Crear consulta LINQ
            List<BoxxProduct> boxxProducts = await _context.BoxxProducts.ToListAsync();

            return boxxProducts;
        }
        public async Task<List<BoxxProduct>> AddBoxxProduct(int boxId, List<int> ProductIds)
        {
            //Método llamado desde BoxxRepository

            List<BoxxProduct> arrBoxxProducts = new List<BoxxProduct>();

            //Por cada ProductId en el array de ProductIds crear un nuevo BoxxProduct y añadirlo a la bd
            foreach (int productId in ProductIds)
            {
                BoxxProduct boxxProduct = new BoxxProduct();
                boxxProduct.ProductId = productId;
                boxxProduct.BoxId = boxId;

                var boxxProductAdded = await _context.BoxxProducts.AddAsync(boxxProduct);
                arrBoxxProducts.Add(boxxProductAdded.Entity);
            }

            _context.SaveChanges();

            return arrBoxxProducts;
        }

        public async Task<List<Product>> GetProductByIdBox(int idbox)
        {
            //Consulta para la obtención de los Productos a partir del Id de la Caja
            List<Product> product = await (from bp in _context.BoxxProducts
                                           join p in _context.Products on bp.ProductId equals p.Id
                                           where bp.BoxId == idbox
                                           select p).ToListAsync();

            return product;
        }
    }
}
