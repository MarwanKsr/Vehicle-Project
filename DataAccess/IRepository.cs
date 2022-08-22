using Microsoft.AspNetCore.Mvc;
using Vehicl_Project.Models;

namespace Vehicl_Project.DataAccess
{
    public interface IRepository<T> where T : Vehicle
    {
        Task<IList<T>> Index();
        Task<T> DetailsById(int id);
        Task Create(T entity);
        Task Edit(T entity);
        Task Delete(int id);
        Task<bool> IsExists(int id);
        Task<bool> IsTableExists();
        Task<T> GetById(int id);
        Task<IEnumerable<Color>> GetColors();
        Task<string> SetColorNameById(int id);

    }
}
