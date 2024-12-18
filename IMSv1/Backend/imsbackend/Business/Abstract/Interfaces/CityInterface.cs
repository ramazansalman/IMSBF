using System.Collections.Generic;
using System.Threading.Tasks;
using imsbackend.Entities.Concrete;

namespace imsbackend.Business.Abstract.Interfaces
{
    public interface CityInterface
    {
        List<City> GetAll();
        Task<City> GetByIdAsync(int id);
    }
}