using System.Threading.Tasks;
using System.Collections.Generic;
using Manager.Domain.Entities;

namespace Manager.Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<List<User>> SearchByEmail(string email);
        Task<List<User>> SearchByName(string name);
        Task<List<User>> SearchByCpf(string cpf);
    }
}