using Microsoft.EntityFrameworkCore;
using Vehicl_Project.Areas.Identity.Data;
using Vehicl_Project.Models;

namespace Vehicl_Project.DataAccess
{
    public class BoatRepository : IBoatRepository
    {
        private readonly Vehicle_ProjectDbContext _context;

        public BoatRepository(Vehicle_ProjectDbContext context)
        {
            _context = context;
        }
        public async Task Create(Boat entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var boat = await _context.Boats.FirstOrDefaultAsync(c => c.Id == id);
            _context.Boats.Remove(boat);
            await _context.SaveChangesAsync();
        }

        public async Task<Boat> DetailsById(int id)
        {
            var boat = await _context.Boats.FindAsync(id);
            return boat; 
        }

        public async Task Edit(Boat entity)
        {
            var boat = _context.Boats.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Boat> GetById(int id)
        {
            var boat = await _context.Boats.FirstOrDefaultAsync(c => c.Id == id);
            return boat;
        }

        public async Task<IEnumerable<Color>> GetColors()
        {
            var colors = await _context.Colors.ToListAsync();
            return colors;
        }

        public async Task<IList<Boat>> Index()
        {
            var boats = _context.Boats.Include(c => c.Color);
            return await boats.ToListAsync();
        }

        public async Task<bool> IsExists(int id)
        {
            var boat = await _context.Boats.AnyAsync(c => c.Id == id);
            return boat;
        }

        public async Task<bool> IsTableExists()
        {
            var boats = await _context.Boats.AnyAsync();
            return boats;
        }

        public async Task<string> SetColorNameById(int id)
        {
            var color = await _context.Colors.FirstOrDefaultAsync(c => c.Id == id);
            return color.Name;
        }
    }
}
