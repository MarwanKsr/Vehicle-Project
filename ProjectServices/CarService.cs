using AutoMapper;
using Vehicl_Project.DataAccess;
using Vehicl_Project.Models;
using Vehicl_Project.ViewModel;

namespace Vehicl_Project.ProjectServices
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        
        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task Create(AddCarVM entity)
        {
            var car = _mapper.Map<Car>(entity);
            await _carRepository.Create(car);
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

        public async Task Edit(EditCarVM entity)
        {
            var car = _mapper.Map<Car>(entity);
            await _carRepository.Edit(car);
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

        public async Task<EditCarVM> GetForEdit(int id)
        {
            var car = await _carRepository.GetById(id);
            var result = _mapper.Map<EditCarVM>(car);
            return result;
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

        
    }
}
