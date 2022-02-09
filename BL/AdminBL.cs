using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entity;
using Microsoft.Extensions.Logging;

namespace BL
{
    public class AdminBL : IAdminBL
    {
        ILogger<AdminBL> logger;
        IAdminDL Admindl;

        public AdminBL(IAdminDL admindl, ILogger<AdminBL> logger)
        {
            this.logger = logger;
            this.Admindl = admindl;
        }
        //get
        public async Task<List<Admin>> GetAdmins()
        {
            //try
            //{
            //    return await Admindl.GetAdmins();
            //}
            //catch (Exception ex)
            //{
            //    logger.LogError("hi");
            //}
            //return null;
            return await Admindl.GetAdmins();
        }
        //getById
        public async Task<Admin> GetAdminById(int id)
        {
            return await Admindl.GetAdminById(id);
        }
        //getByIdNumber
        public async Task<Admin> GetAdmintByIdNumber(string idnum)
        {
            return await Admindl.GetAdmintByIdNumber(idnum);
        }
        // post

        public async Task<int> PostAdmin(Admin new_admin)
        {
            return await Admindl.PostAdmin(new_admin);

        }
        //put
        public async Task<Admin> PutAdmin(Admin admin)
        {
            return await Admindl.PutAdmin(admin);

        }
        //delete
        public async Task DeleteAdmin(int id)
        {
            await Admindl.DeleteAdmin(id);
        }
    }
}//
