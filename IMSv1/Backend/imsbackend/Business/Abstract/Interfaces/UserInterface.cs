using System.Collections.Generic;
using System.Threading.Tasks;
using imsbackend.Entities.Concrete;

namespace imsbackend.Business.Abstract.Interfaces
{
    public interface UserInterface
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(int id, User user);
        Task<bool> DeleteAsync(int id);
    }
}