using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts;
using Agraja.Infrastructure.Contracts.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Agraja.Infrastructure.Repositories
{
    public class AgroRepository : IAgroRepository
    {
        private readonly AgrajaDbContext _context;
        private readonly IAgroxProductRepository _agroxProductRepository;

        public AgroRepository(AgrajaDbContext dbcontext, IAgroxProductRepository agroxProductRepository)
        {
            //Este método lo utilizamos para privatizar el contexto
            _context = dbcontext;
            _agroxProductRepository = agroxProductRepository;

        }

        public async Task<List<Agro>> GetAll()
        {
            //Crear consulta LINQ
            List<Agro> agros = await _context.Agros.ToListAsync();

            return agros;
        }

        public async Task<Agro> AddAgro(AgroAddRequestDto newAgro)
        {
            //Recogemos los datos del form del Front y convertimos el objeto en Agro
            AgroAddRequestDto agroRequestDto = newAgro;

            Agro agro = new Agro();
            agro.Name = agroRequestDto.Name;
            agro.Description = agroRequestDto.Description;
            agro.Province = agroRequestDto.Province;
            agro.Prize = agroRequestDto.Prize;
            agro.Picture = agroRequestDto.Picture;

            //Añadir el Agro a la bd
            var agroAdded = await _context.Agros.AddAsync(agro);
            _context.SaveChanges();

            Agro agroCreated = agroAdded.Entity;//Entity provoca que solo devuelva un objeto de tipo Agro

            //Llamada a la función del AgroxProductRepository para añadir los datos a la tabla AgroxProducts
            await _agroxProductRepository.AddAgroxProduct(agroCreated.Id, agroRequestDto.ProductIds);
        
            return agroCreated;
        }

        public async Task<Agro> UpdateAgroById(int id, AgroUpdateRequestDto agroUpdate)
        {
            Agro? agroResult = await _context.Agros.Where(x => x.Id == id).FirstOrDefaultAsync();

            //En el caso que la consulta devuelva null, que salga el siguiente error
            if (agroResult == null)
            {
                throw new ArgumentNullException(nameof(agroResult), "No se ha encontrado el Agro en la bd.");
            }

            //Actualización de los campos enviados desde el Front
            agroResult.Name = agroUpdate.Name;
            agroResult.Description = agroUpdate.Description;

            _context.Agros.Update(agroResult);
            _context.SaveChanges();

            return agroResult;
        }

        public async Task<Agro> DeleteAgroById(int id)
        {
            Agro? agroRemoved =  _context.Agros.Where(x =>x.Id == id).FirstOrDefault();
            
            //En el caso que la consulta devuelva null, que salga el siguiente error
            if (agroRemoved == null)
            {
                throw new ArgumentNullException(nameof(agroRemoved), "No se ha encontrado el Agro en la bd.");
            }

            //Eliminación del Agro de la bd
            _context.Agros.Remove(agroRemoved);
            await _context.SaveChangesAsync();

            return agroRemoved;
        }

        public async Task<Agro> GetAgroById(int id)
        {
            Agro? agroReturned = await _context.Agros.Where(x => x.Id == id).FirstOrDefaultAsync();

            //En el caso que la consulta devuelva null, que salga el siguiente error
            if (agroReturned == null)
            {
                throw new ArgumentNullException(nameof(agroReturned), "No se ha encontrado el Agro en la bd.");
            }

            return agroReturned;
        }
    }
}
