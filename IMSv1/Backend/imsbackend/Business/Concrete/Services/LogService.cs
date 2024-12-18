using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using imsbackend.Business.Abstract.Interfaces;
using imsbackend.DataAccess;
using imsbackend.Entities.Concrete;

namespace imsbackend.Business.Concrete.Services
{
    public class LogService : LogInterface
    {
        private readonly AppDbContext _dbContext;

        public LogService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Log>> ListLog()
        {
            return await _dbContext.Logs.ToListAsync();
        }

        public async Task<Log> GetLogById(int id)
        {
            return await _dbContext.Logs.FindAsync(id);
        }

        public async Task AddLog(Log log)
        {
            _dbContext.Logs.Add(log);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateLog(Log log)
        {
            _dbContext.Entry(log).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteLog(int id)
        {
            var log = await _dbContext.Logs.FindAsync(id);
            if (log != null)
            {
                _dbContext.Logs.Remove(log);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Log>> GetAllLogsAsync()
        {
            return await _dbContext.Logs.ToListAsync();
        }

        public async Task<IEnumerable<Log>> SearchLogsAsync(string term)
        {
            return await _dbContext.Logs
                .Where(l => l.Status.Contains(term) ||
                            l.OperationType.Contains(term) ||
                            l.Description.Contains(term) ||
                            l.UserType.Contains(term))
                .ToListAsync();
        }
    }
}
