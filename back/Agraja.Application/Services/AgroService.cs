using Agraja.Application.Contracts.Services;
using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts;
using Agraja.Infrastructure.Contracts.DTOs;

namespace Agraja.Application.Services
{
    public class AgroService : IAgroService
    {   //Conexión entre Service y Repository
        private readonly IAgroRepository _agroRepository;

        public AgroService(IAgroRepository agroRepository) 
        {
            _agroRepository = agroRepository;
        }

        public async Task<List<Agro>> GetAll()
        {
            //El metodo nos devuelve los datos que queremos del Repository
            List<Agro> agros = await _agroRepository.GetAll();

            return agros;
        }

        public async Task<Agro> AddAgro(AgroAddRequestDto newAgro)
        {
            //En el caso que el Front envíe newAgro como nulo que salga el siguiente error
            if (newAgro == null) 
            {
                throw new ArgumentNullException(nameof(newAgro), "El argumento newAgro no puede ser nulo.");
            }

            Agro agroAdded = await _agroRepository.AddAgro(newAgro);
            return agroAdded;
        }

        public async Task<Agro> UpdateAgroById(int id, AgroUpdateRequestDto agroUpdate)
        {
            //En el caso que el Front envíe newAgro como nulo que salga el siguiente error
            if (agroUpdate == null)
            {
                throw new ArgumentNullException(nameof(agroUpdate), "El argumento agroUpdate no puede ser nulo.");
            }

            Agro agroUpdated = await _agroRepository.UpdateAgroById(id, agroUpdate);
            
            return agroUpdated;
        }
        
        public async Task<Agro> DeleteAgroById(int agroId)
        {

            Agro deletedAgro = await _agroRepository.DeleteAgroById(agroId);

            return deletedAgro;
        }

        public async Task<Agro> GetAgroById(int id)
        {

            Agro agroId = await _agroRepository.GetAgroById(id);

            return agroId;

        }
    }
}
