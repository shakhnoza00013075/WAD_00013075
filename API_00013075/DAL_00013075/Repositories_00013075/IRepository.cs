using System.Threading.Tasks;

namespace DAL_00013075.Repositories_00013075
{
    public interface IRepository<T>
    {
        Task<T?> Get(int id);
        Task<ICollection<T>> GetAll();
        Task Create(T entity);
        Task Edit(int id, T entity);
        Task Delete(int id);
    }
}
