using Entity;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserDL
    {
        Task<User> getUser(string Id, string password);
        Task<User> GetUserByIdNumber(string id);
        Task<User> AddUser(User user);
    }
}