using Vehicl_Project.Models;

namespace Vehicl_Project.ProjectServices
{
    public interface ICarService
    {
        Task<IList<Car>> Index();
        Task<Car> DetailsById(int id);
        Task Create(Car entity);
        Task Edit(Car entity);
        Task Delete(int id);
        Task<bool> IsExists(int id);
        Task<bool> IsTableExists();
        Task<IEnumerable<Color>> GetColors();
        Task<string> SetColorNameById(int id);
        Task<Car> GetById(int id);
    }
}
