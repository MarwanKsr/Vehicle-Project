using Vehicl_Project.DataAccess;
using Vehicl_Project.Models;

namespace Vehicl_Project.ProjectServices
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepository;

        public BusService(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public async Task Create(Bus entity)
        {
            await _busRepository.Create(entity);
        }

        public async Task Delete(int id)
        {
            await _busRepository.Delete(id);
        }

        public async Task<Bus> DetailsById(int id)
        {
            var bus = await _busRepository.DetailsById(id);
            return bus;
        }

        public async Task Edit(Bus entity)
        {
            await _busRepository.Edit(entity);
        }

        public async Task<Bus> GetById(int id)
        {
            var bus = await _busRepository.GetById(id);
            return bus;
        }

        public async Task<IEnumerable<Color>> GetColors()
        {
            var colors = await _busRepository.GetColors();
            return colors;
        }

        public async Task<IList<Bus>> Index()
        {
            var buses = await _busRepository.Index();
            return buses;
        }

        public Task<bool> IsExists(int id)
        {
            var bus = _busRepository.IsExists(id);
            return bus;
        }

        public Task<bool> IsTableExists()
        {
            var buses = _busRepository.IsTableExists();
            return buses;
        }
    }
}
