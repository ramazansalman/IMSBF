using System.Threading.Tasks;
using imsbackend.Entities.Concrete;

namespace imsbackend.Business.Abstract.Interfaces
{
    public interface AuthInterface
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string eMail, string password);
        Task<bool> UserExists(string eMail);
        Task<User> GetUserById(int id);
        Task<bool> IsAdmin(string eMail);
    }

}