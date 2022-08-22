using Vehicl_Project.Models;

namespace Vehicl_Project.DataAccess
{
    public interface IColorRepository
    {
        Task<IList<Color>> Index();
        Task Create(Color entity);
        Task Delete(int id);
        Task<Color> GetById(int id);
        Task<bool> IsExists(int id);
        Task<bool> IsTableExists();


    }
}
