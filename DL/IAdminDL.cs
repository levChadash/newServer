using Entity;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IAdminDL
    {
        Task DeleteAdmin(int id);
        Task<Admin> GetAdminById(int id);
        Task<Admin> GetAdmintByIdNumber(string idnum);
        Task<List<Admin>> GetAdmins();
        Task<int> PostAdmin(Admin new_admin);
        Task<Admin> PutAdmin(Admin admin);
    }
}