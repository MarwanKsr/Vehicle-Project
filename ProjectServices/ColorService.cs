using Vehicl_Project.DataAccess;
using Vehicl_Project.Models;

namespace Vehicl_Project.ProjectServices
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;

        public ColorService(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task Create(Color entity)
        {
            await _colorRepository.Create(entity);
        }

        public async Task Delete(int id)
        {
            await _colorRepository.Delete(id);
        }

        public async Task<Color> GetById(int id)
        {
            return await _colorRepository.GetById(id);
        }

        public async Task<IList<Color>> Index()
        {
            return await _colorRepository.Index();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _colorRepository.IsExists(id);
        }

        public async Task<bool> IsTableExists()
        {
            return await _colorRepository.IsTableExists();
        }
    }
}
