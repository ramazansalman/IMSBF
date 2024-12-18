using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using imsbackend.Business.Abstract.Interfaces;
using imsbackend.DataAccess;
using imsbackend.Entities.Concrete;
namespace imsbackend.Business.Concrete.Services
{
    public class ImmovableService : ImmovableInterface
    {
        private readonly AppDbContext _dbContext;

        public ImmovableService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Immovable> AddAsync(Immovable Immovable)
        {
            await _dbContext.Immovables.AddAsync(Immovable);
            await _dbContext.SaveChangesAsync();
            return Immovable;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Immovable = await _dbContext.Immovables.FindAsync(id);
            if (Immovable == null)
                return false;

            _dbContext.Immovables.Remove(Immovable);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public IEnumerable<Immovable> GetAll()
        {
            return _dbContext.Immovables
                             .Include(t => t.Neighborhood)
                             .ThenInclude(x => x.District)
                             .ThenInclude(l => l.City)
                             .Include(t => t.User)
                             .ToList();
        }

        public Immovable GetById(int id)
        {
            return _dbContext.Immovables
                             .Include(t => t.Neighborhood)
                             .ThenInclude(x => x.District)
                             .ThenInclude(l => l.City)
                             .Include(t => t.User)
                             .FirstOrDefault(t => t.Id == id);
        }

        public async Task<Immovable> GetByIdAsync(int id)
        {
            return await _dbContext.Immovables
                                   .Include(t => t.Neighborhood)
                                   .ThenInclude(x => x.District)
                                   .ThenInclude(l => l.City)
                                   .Include(t => t.User)
                                   .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Immovable> UpdateAsync(int id, Immovable Immovable)
        {
            var existingImmovable = await _dbContext.Immovables
                                                   .FirstOrDefaultAsync(t => t.Id == id);
            if (existingImmovable == null)
                return null;

            existingImmovable.NeighborhoodId = Immovable.NeighborhoodId;
            existingImmovable.Parcel = Immovable.Parcel;
            existingImmovable.Coordinates = Immovable.Coordinates;
            existingImmovable.Type = Immovable.Type;
            existingImmovable.Block = Immovable.Block;

            await _dbContext.SaveChangesAsync();
            return existingImmovable;
        }

        public async Task<IEnumerable<Immovable>> GetByUserIdAsync(int userId)
        {
            return await _dbContext.Immovables
                                   .Where(t => t.UserId == userId)
                                   .Include(t => t.Neighborhood)
                                   .ThenInclude(x => x.District)
                                   .ThenInclude(l => l.City)
                                   .ToListAsync();
        }
        /*
        public Task<Immovable> AddAsync(Immovable immovable)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Immovable> ImmovableInterface.GetAll()
        {
            throw new System.NotImplementedException();
        }

        Immovable ImmovableInterface.GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<Immovable> ImmovableInterface.GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Immovable> UpdateAsync(int id, Immovable immovable)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<Immovable>> ImmovableInterface.GetByUserIdAsync(int userId)
        {
            throw new System.NotImplementedException();
        }
        */
    }
}