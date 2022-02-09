using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IRegisterBL
    {
        Task deleteRegister(int id);
        Task<List<Register>> GetRegister();
        Task<int> postRegister(Register rg);
        Task<Register> putRegister(Register rg);
    }
}