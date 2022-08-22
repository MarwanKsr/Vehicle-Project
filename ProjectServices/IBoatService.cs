using Vehicl_Project.Models;

namespace Vehicl_Project.ProjectServices
{
    public interface IBoatService
    {
        Task<IList<Boat>> Index();
        Task<Boat> DetailsById(int id);
        Task Create(Boat entity);
        Task Edit(Boat entity);
        Task Delete(int id);
        Task<bool> IsExists(int id);
        Task<bool> IsTableExists();
        Task<Boat> GetById(int id);
        Task<IEnumerable<Color>> GetColors();
        Task<string> SetColorNameById(int id);
    }
}
