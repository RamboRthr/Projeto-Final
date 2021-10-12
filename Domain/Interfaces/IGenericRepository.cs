using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> Create(T entity);
        void Update(T entity);
        Task Delete(int id);
        Task<T> GetById(int id);
        Task Save();
    }
}
