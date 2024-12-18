using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using imsbackend.Business.Abstract.Interfaces;
using imsbackend.DataAccess;
using imsbackend.Entities.Concrete;

namespace imsbackend.Business.Concrete.Services
{
    public class CityService : CityInterface
    {
        private AppDbContext _dbContext;

        public CityService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<City> GetAll()
        {
            return _dbContext.Cities.ToList();
        }

        public City GetById(int id)
        {
            return _dbContext.Cities.FirstOrDefault(city => city.Id == id);
        }

        public async Task<City> GetByIdAsync(int id)
        {
            return await _dbContext.Cities.FirstOrDefaultAsync(city => city.Id == id);
        }
    }
}