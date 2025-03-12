using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNhanSu2025.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id); // Cho phép null
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}