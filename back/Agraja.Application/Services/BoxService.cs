using Agraja.Application.Contracts.Services;
using Agraja.Domain.Models;
using Agraja.Infrastructure.Contracts;
using Agraja.Infrastructure.Contracts.DTOs;

namespace Agraja.Application.Services
{
    public class BoxService : IBoxService
    {   //Conexión entre Service y Repository
        private readonly IBoxRepository _boxRepository;

        public BoxService(IBoxRepository boxRepository)
        {
            _boxRepository = boxRepository;
        }

        public async Task<List<Box>> GetAll()
        {
            //El metodo nos devuelve los datos que queremos del Repository
            List<Box> boxes = await _boxRepository.GetAll();

            return boxes;
        }

        public async Task<Box> AddBox(BoxAddRequestDto newBox)
        {
            //En el caso que el Front envíe newBox como nulo que salga el siguiente error
            if (newBox == null)
            {
                throw new ArgumentNullException(nameof(newBox), "El argumento newBox no puede ser nulo.");
            }

            Box boxAdded = await _boxRepository.AddBox(newBox);

            return boxAdded;
        }

        public async Task<Box> UpdateBoxById(int id, BoxUpdateRequestDto boxUpdate)
        {
            //En el caso que el Front envíe boxUpdate como nulo que salga el siguiente error
            if (boxUpdate == null)
            {
                throw new ArgumentNullException(nameof(boxUpdate), "El argumento boxUpdate no puede ser nulo.");
            }

            Box boxUpdated = await _boxRepository.UpdateBoxById(id, boxUpdate);
            return boxUpdated;
        }

        public async Task<Box> DeleteBoxById(int boxId)
        {

            Box deletedBox = await _boxRepository.DeleteBoxById(boxId);

            return deletedBox;

        }

        public async Task<Box> GetBoxById(int id)
        {

            Box boxId = await _boxRepository.GetBoxById(id);

            return boxId;

        }
    }
}
