using System.Collections.Generic;
using System.Threading.Tasks;
using imsbackend.Entities.Concrete;

namespace imsbackend.Business.Abstract.Interfaces
{
    public interface NeighborhoodInterface
    {
        Task<List<Neighborhood>> GetAll();
        Task<Neighborhood> GetByIdAsync(int id);
        Task<IEnumerable<Neighborhood>> GetByDistrictIdAsync(int districtId);
    }
}