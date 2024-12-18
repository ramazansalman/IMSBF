using System.Collections.Generic;
using System.Threading.Tasks;
using imsbackend.Entities.Concrete;

namespace imsbackend.Business.Abstract.Interfaces
{
    public interface ImmovableInterface
    {
        Task<Immovable> AddAsync(Immovable immovable);
        Task<bool> DeleteAsync(int id);
        IEnumerable<Immovable> GetAll();
        Immovable GetById(int id);
        Task<Immovable> GetByIdAsync(int id);
        Task<Immovable> UpdateAsync(int id, Immovable immovable);
        Task<IEnumerable<Immovable>> GetByUserIdAsync(int userId);
    }
}