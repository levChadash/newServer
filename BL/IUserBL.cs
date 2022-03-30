using Entity;
using System.Threading.Tasks;

namespace BL
{
    public interface IUserBL
    {
        Task<User> GetUser(string email, string password);
        Task<User> GetUserById(string id);
        Task<User> AddUser(User user);
    }
}