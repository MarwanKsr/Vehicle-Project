using Microsoft.EntityFrameworkCore;
using Vehicl_Project.Areas.Identity.Data;
using Vehicl_Project.Models;

namespace Vehicl_Project.DataAccess
{
    public class ColorRepository : IColorRepository
    {
        private readonly Vehicle_ProjectDbContext _context;

        public ColorRepository(Vehicle_ProjectDbContext context)
        {
            _context = context;
        }

        public async Task Create(Color entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var color = await _context.Colors.FirstAsync(c => c.Id == id);
            _context.Colors.Remove(color);
            await _context.SaveChangesAsync();
        }

        public async Task<Color> GetById(int id)
        {
            var color = await _context.Colors.FirstOrDefaultAsync(c => c.Id == id);
            return color;
        }

        public async Task<IList<Color>> Index()
        {
            return await _context.Colors.ToListAsync();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.Colors.AnyAsync(c => c.Id == id);
            
        }

        public async Task<bool> IsTableExists()
        {
            return await _context.Colors.AnyAsync();
            
        }
    }
}
