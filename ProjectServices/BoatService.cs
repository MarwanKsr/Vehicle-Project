using Vehicl_Project.DataAccess;
using Vehicl_Project.Models;

namespace Vehicl_Project.ProjectServices
{
    public class BoatService : IBoatService
    {
        private readonly IBoatRepository _boatRepository;

        public BoatService(IBoatRepository boatRepository)
        {
            _boatRepository = boatRepository;
        }

        public async Task Create(Boat entity)
        {
            await _boatRepository.Create(entity);
        }

        public async Task Delete(int id)
        {
            await _boatRepository.Delete(id);
        }

        public async Task<Boat> DetailsById(int id)
        {
            var boat = await _boatRepository.DetailsById(id);
            return boat;
        }

        public async Task Edit(Boat entity)
        {
            await _boatRepository.Edit(entity);
        }

        public async Task<Boat> GetById(int id)
        {
            var boat = await _boatRepository.GetById(id);
            return boat;
        }

        public async Task<IEnumerable<Color>> GetColors()
        {
            var colors = await _boatRepository.GetColors();
            return colors;
        }

        public Task<IList<Boat>> Index()
        {
            var boats = _boatRepository.Index();
            return boats;
        }

        public Task<bool> IsExists(int id)
        {
            var boat = _boatRepository.IsExists(id);
            return boat;
        }

        public Task<bool> IsTableExists()
        {
            var boats = _boatRepository.IsTableExists();
            return boats;
        }

        public async Task<string> SetColorNameById(int id)
        {
            return await _boatRepository.SetColorNameById(id);
        }
    }
}
