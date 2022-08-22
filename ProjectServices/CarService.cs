using Vehicl_Project.DataAccess;
using Vehicl_Project.Models;

namespace Vehicl_Project.ProjectServices
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task Create(Car entity)
        {
             await _carRepository.Create(entity);
        }

        public async Task Delete(int id)
        {
            await _carRepository.Delete(id);
        }

        public async Task<Car> DetailsById(int id)
        {
            var car = await _carRepository.DetailsById(id);
            return car;
        }

        public async Task Edit(Car entity)
        {
            await _carRepository.Edit(entity);
        }

        public async Task<Car> GetById(int id)
        {
            var car = await _carRepository.GetById(id);
            return car;
        }

        public async Task<IEnumerable<Color>> GetColors()
        {
           var colors = await _carRepository.GetColors();
            return colors;
        }

        public async Task<IList<Car>> Index()
        {
            var Cars = await _carRepository.Index();
            return Cars;
        }

        public async Task<bool> IsExists(int id)
        {
            var car = await _carRepository.IsExists(id);
            return car;
        }

        public async Task<bool> IsTableExists()
        {
            var cars = await _carRepository.IsTableExists();
            return cars;
        }

        public async Task<string> SetColorNameById(int id)
        {
            return await _carRepository.SetColorNameById(id);
        }
    }
}
