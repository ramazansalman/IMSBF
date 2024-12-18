using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using imsbackend.Business.Abstract.Interfaces;
using imsbackend.DataAccess;
using imsbackend.Entities.Concrete;

namespace imsbackend.Business.Concrete.Services
{
    public class NeighborhoodService : NeighborhoodInterface
    {
        private readonly AppDbContext _dbContext;

        public NeighborhoodService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Neighborhood>> GetAll()
        {
            return await _dbContext.Neighborhoods
                                   .Include(n => n.District)
                                   .ThenInclude(d => d.City)
                                   .ToListAsync();
        }

        public async Task<Neighborhood> GetByIdAsync(int id)
        {
            return await _dbContext.Neighborhoods
                                   .Include(n => n.District)
                                   .ThenInclude(d => d.City)
                                   .FirstOrDefaultAsync(neigborhood => neigborhood.Id == id);
        }

        public async Task<IEnumerable<Neighborhood>> GetByDistrictIdAsync(int districtId)
        {
            return await _dbContext.Neighborhoods
                                   .Include(n => n.District)
                                   .ThenInclude(d => d.City)
                                   .Where(n => n.DistrictId == districtId)
                                   .ToListAsync();
        }
        /*
        Task<List<Neighborhood>> NeighborhoodInterface.GetAll()
        {
            throw new System.NotImplementedException();
        }

        Task<Neighborhood> NeighborhoodInterface.GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<Neighborhood>> NeighborhoodInterface.GetByDistrictIdAsync(int districtId)
        {
            throw new System.NotImplementedException();
        }
        */
    }
}