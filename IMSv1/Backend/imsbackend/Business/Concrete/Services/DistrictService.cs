using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using imsbackend.Business.Abstract.Interfaces;
using imsbackend.DataAccess;
using imsbackend.Entities.Concrete;

namespace imsbackend.Business.Concrete.Services
{
    public class DistrictService : DistrictInterface
    {
        private readonly AppDbContext _context;

        public DistrictService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<District>> GetAll()
        {
            return await _context.Districts
                .Include(d => d.City)
                .ToListAsync();
        }

        public async Task<District> GetByIdAsync(int id)
        {
            return await _context.Districts
                .Include(d => d.City)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<District>> GetByCityIdAsync(int cityId)
        {
            return await _context.Districts
                .Include(d => d.City)
                .Where(d => d.CityId == cityId)
                .ToListAsync();
        }
    }
}