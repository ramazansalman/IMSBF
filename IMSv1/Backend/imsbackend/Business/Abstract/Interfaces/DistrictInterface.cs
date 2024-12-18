using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using imsbackend.Entities.Concrete;

namespace imsbackend.Business.Abstract.Interfaces
{
    public interface DistrictInterface
    {
        Task<List<District>> GetAll();
        Task<District> GetByIdAsync(int id);
        Task<IEnumerable<District>> GetByCityIdAsync(int cityId);
    }
}