using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts;
using Agraja.Infrastructure.Contracts.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Agraja.Infrastructure.Repositories
{
    public class BoxRepository : IBoxRepository
    {
        private readonly AgrajaDbContext _context;
        private readonly IBoxxProductRepository _boxxProductRepository;

        public BoxRepository(AgrajaDbContext dbcontext, IBoxxProductRepository boxxProductRepository) 
        { 
            //Este método lo utilizamos para privatizar el contexto
            _context = dbcontext;
            _boxxProductRepository = boxxProductRepository;
        }

        public async Task<List<Box>> GetAll()
        {
            //Crear consulta LINQ
            List<Box> boxes = await _context.Boxes.ToListAsync();

            return boxes;
        }

        public async Task<Box> AddBox(BoxAddRequestDto newBox)
        {
            //Recogemos los datos del form del Front y convertimos el objeto en Box
            BoxAddRequestDto boxRequestDto = newBox;

            Box box = new Box();
            box.Name = boxRequestDto.Name;
            box.Description = boxRequestDto.Description;
            box.Kg = boxRequestDto.Kg;
            box.Prize = boxRequestDto.Prize;
            box.Stock = boxRequestDto.Stock;
            box.Picture = boxRequestDto.Picture;

            //Añadir la Caja a la bd
            var boxAdded = await _context.Boxes.AddAsync(box);
            _context.SaveChanges();

            Box boxCreated = boxAdded.Entity;//Entity provoca que solo devuelva un objeto de tipo Box

            //LLamada a la función del BoxxProductRepository para añadir los datos a la tabla BoxxProducts
            await _boxxProductRepository.AddBoxxProduct(boxCreated.Id, boxRequestDto.ProductIds);

            return boxCreated;
        }

        public async Task<Box> UpdateBoxById(int id, BoxUpdateRequestDto boxUpdate)
        {
            Box? boxResult = await _context.Boxes.Where(x => x.Id == id).FirstOrDefaultAsync();

            //En el caso que la consulta devuelva null, que salga el siguiente error
            if (boxResult == null)
            {
                throw new ArgumentNullException(nameof(boxResult), "No se ha encontrado la Caja en la bd.");
            }

            //Actualización de los campos enviados desde el Front
            boxResult.Name = boxUpdate.Name;
            boxResult.Description = boxUpdate.Description;
            boxResult.Stock = boxUpdate.Stock;

            _context.Boxes.Update(boxResult);
            _context.SaveChanges();

            return boxResult;
        }

        public async Task<Box> DeleteBoxById(int id)
        {
            Box? boxRemoved =  _context.Boxes.Where(x => x.Id == id).FirstOrDefault();

            //En el caso que la consulta devuelva null, que salga el siguiente error
            if (boxRemoved == null)
            {
                throw new ArgumentNullException(nameof(boxRemoved), "No se ha encontrado la Caja en la bd.");
            }

            //Eliminación del Agro de la bd
            _context.Remove(boxRemoved);
            await _context.SaveChangesAsync();

            return boxRemoved;
        }

        public async Task<Box> GetBoxById(int id)
        {
            Box? boxReturned = await _context.Boxes.Where(x => x.Id == id).FirstOrDefaultAsync();

            //En el caso que la consulta devuelva null, que salga el siguiente error
            if (boxReturned == null)
            {
                throw new ArgumentNullException(nameof(boxReturned), "No se ha encontrado la Caja en la bd.");
            }

            return boxReturned;
        }

    }
}
