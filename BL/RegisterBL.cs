using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entity;

namespace BL
{
    public class RegisterBL : IRegisterBL
    {
        IRegisterDL registerdl;
        public RegisterBL(IRegisterDL registerdl)
        {
            this.registerdl = registerdl;
        }

        //get
        public async Task<List<Register>> GetRegister()
        {
            return await registerdl.GetRegister();
        }

        //post
        public async Task<int> postRegister(Register rg)
        {
            return await registerdl.postRegister(rg);

        }
        //put
        public async Task<Register> putRegister(Register rg)
        {
            return await registerdl.putRegister(rg);
        }
        //delete
        public async Task deleteRegister(int id)
        {
            await registerdl.deleteRegister(id);
        }

    }
}
