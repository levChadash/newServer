using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class RegisterDL : IRegisterDL
    {
        VolunteerContext vrc;
        public RegisterDL(VolunteerContext vrc)
        {
            this.vrc = vrc;
        }
        //get
        public async Task<List<Register>> GetRegister()
        {
            List<Register> registers = await vrc.Registers.ToListAsync();
            return registers;
        }
        //getById
        public async Task<Register> getRegisterById(int id)
        {
            Register RegisterById = await vrc.Registers.FindAsync(id);
            return RegisterById;

        }
        //post
        public async Task<int> postRegister(Register rg)
        {
            await vrc.Registers.AddAsync(rg);
            await vrc.SaveChangesAsync();
            return rg.Id;
        }
        //put
        public async Task<Register> putRegister(Register rg)
        {
            Register registerToUpDate = await vrc.Registers.FindAsync(rg.Id);
            if (registerToUpDate == null)
                return null;
            vrc.Entry(registerToUpDate).CurrentValues.SetValues(rg);
            await vrc.SaveChangesAsync();
            return rg;
        }
        //delete
        public async Task deleteRegister(int id)
        {
            Register rt = await vrc.Registers.FindAsync(id);
            if (rt == null)
                throw new Exception();
            vrc.Registers.Remove(rt);
            await vrc.SaveChangesAsync();
        }

    }
}
