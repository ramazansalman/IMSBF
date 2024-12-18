using System.Collections.Generic;
using System.Threading.Tasks;
using imsbackend.Entities.Concrete;

namespace imsbackend.Business.Abstract.Interfaces
{
    public interface LogInterface
    {
        Task<List<Log>> ListLog();
        Task<Log> GetLogById(int id);
        Task AddLog(Log log);
        Task UpdateLog(Log log);
        Task DeleteLog(int id);

        Task<IEnumerable<Log>> GetAllLogsAsync();
        Task<IEnumerable<Log>> SearchLogsAsync(string term);
    }
}