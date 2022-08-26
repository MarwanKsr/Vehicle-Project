using Vehicl_Project.Models;

namespace Vehicl_Project.ProjectServices
{
    public interface IBusService
    {
        Task<IList<Bus>> Index();
        Task<Bus> DetailsById(int id);
        Task Create(Bus entity);
        Task Edit(Bus entity);
        Task Delete(int id);
        Task<bool> IsExists(int id);
        Task<bool> IsTableExists();
        Task<IEnumerable<Color>> GetColors();
        Task<Bus> GetById(int id);
    }
}
