using Manager.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Manager.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> Create(T obj);
        Task<T> Update(T ob);
        Task<T> Remove(long id);
        Task<T> Get(long id);
        Task<List<T>> Get();
    }
}