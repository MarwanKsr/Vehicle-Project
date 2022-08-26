using Microsoft.EntityFrameworkCore;
using Vehicl_Project.Areas.Identity.Data;
using Vehicl_Project.Models;

namespace Vehicl_Project.DataAccess
{
    public class BusRepository : IBusRepository
    {
        Vehicle_ProjectDbContext _context;

        public BusRepository(Vehicle_ProjectDbContext context)
        {
            _context = context;
        }

        public async Task Create(Bus entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var bus = await _context.Buses.FirstOrDefaultAsync(c => c.Id == id);
             _context.Buses.Remove(bus);
            await _context.SaveChangesAsync();
        }

        public async Task<Bus> DetailsById(int id)
        {
            var bus = await _context.Buses.FindAsync(id);
            return bus;
        }

        public async Task Edit(Bus entity)
        {
            var bus = _context.Buses.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Bus> GetById(int id)
        {
            var bus = await _context.Buses.FirstOrDefaultAsync(c => c.Id == id);
            return bus;
            
        }

        public async Task<IEnumerable<Color>> GetColors()
        {
            var colors = await _context.Colors.ToListAsync();
            return colors;
        }

        public async Task<IList<Bus>> Index()
        {
            var buses = _context.Buses.Include(c => c.Color);
            return await buses.ToListAsync();
        }

        public async Task<bool> IsExists(int id)
        {
            var bus = await _context.Buses.AnyAsync(c => c.Id == id);
            return bus;
        }

        public async Task<bool> IsTableExists()
        {
            var buses = await _context.Buses.AnyAsync();
            return buses;
        }
    }
}
