using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IAdminBL
    {
        Task DeleteAdmin(int id);
        Task<Admin> GetAdminById(int id);
        Task<Admin> GetAdmintByIdNumber(string idnum);
        Task<List<Admin>> GetAdmins();
        Task<int> PostAdmin(Admin new_admin);
        Task<Admin> PutAdmin(Admin admin);
    }
}