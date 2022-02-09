using Entity;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class AdminDL : IAdminDL
    {
        VolunteerContext vrc;
        public AdminDL(VolunteerContext vrc)
        {
            this.vrc = vrc;
        }
        //get
        public async Task<List<Admin>> GetAdmins()
        {
            //throw new Exception("aaaaaaaaaaaa");
            List<Admin> AdminL = await vrc.Admins.ToListAsync();
            return AdminL;
        }
        //getById
        public async Task<Admin> GetAdminById(int id)
        {
            Admin admin = await vrc.Admins.FindAsync(id);
            return admin;
        }
        //getByNumberId
        public async Task<Admin> GetAdmintByIdNumber(string idnum)
        {
            return vrc.Admins.Single(sid => sid.Person.IdNumber == idnum);
        }


        //post
        public async Task<int> PostAdmin(Admin new_admin)
        {
            await vrc.Admins.AddAsync(new_admin);
            await vrc.SaveChangesAsync();
            return new_admin.Id;
        }
        //put
        public async Task<Admin> PutAdmin(Admin admin)
        {
            Admin adminToUpDate = await vrc.Admins.FindAsync(admin.Id);
            if (adminToUpDate == null)
            {
                return null;
            }
            vrc.Entry(adminToUpDate).CurrentValues.SetValues(admin);

            await vrc.SaveChangesAsync();
            return admin;
        }
        //delete
        public async Task DeleteAdmin(int id)
        {
            Admin ad = await vrc.Admins.FindAsync(id);
            if (ad == null)
                throw new Exception();
            vrc.Admins.Remove(ad);
            await vrc.SaveChangesAsync();
        }

    }
}
