using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IRegisterDL
    {
        Task deleteRegister(int id);
        Task<List<Register>> GetRegister();
        Task<int> postRegister(Register rg);
        Task<Register> putRegister(Register rg);
        Task<Register> getRegisterById(int id);
    }
}