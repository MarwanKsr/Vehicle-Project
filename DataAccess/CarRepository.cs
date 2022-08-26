using Microsoft.EntityFrameworkCore;
using System.Linq;
using Vehicl_Project.Areas.Identity.Data;
using Vehicl_Project.Models;

namespace Vehicl_Project.DataAccess
{
    public class CarRepository : ICarRepository
    {
        private readonly Vehicle_ProjectDbContext _context;

        public CarRepository(Vehicle_ProjectDbContext context)
        {
            _context = context;
        }
        public async Task Create(Car entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            
        }

        public async Task<Car> DetailsById(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            return car;
        }

        public async Task Edit(Car entity)
        { 
            var car = _context.Cars.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Car> GetById(int id)
        {
            var car = await _context.Cars.SingleOrDefaultAsync(c => c.Id == id);

            return car;
        }

        public async Task<IEnumerable<Color>> GetColors()
        {
            var colors = await _context.Colors.ToListAsync();
            return colors;
        }

        public async Task<IList<Car>> Index()
        {
            var cars = _context.Cars.Include(c => c.Color);
            return await cars.ToListAsync();
        }

        public async Task<bool> IsExists(int id)
        {
           var car = await _context.Cars.AnyAsync(c => c.Id == id);
            return car;
        }

        public async Task<bool> IsTableExists()
        {
            var cars = await _context.Cars.AnyAsync();
            return cars;
        }
    }
}
