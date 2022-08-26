using Vehicl_Project.Models;
using Vehicl_Project.ViewModel;

namespace Vehicl_Project.ProjectServices
{
    public interface ICarService
    {
        Task<IList<Car>> Index();
        Task<Car> DetailsById(int id);
        Task Create(AddCarVM entity);
        Task Edit(EditCarVM entity);
        Task Delete(int id);
        Task<bool> IsExists(int id);
        Task<bool> IsTableExists();
        Task<IEnumerable<Color>> GetColors();
        Task<Car> GetById(int id);
        Task<EditCarVM> GetForEdit(int id);
    }
}
