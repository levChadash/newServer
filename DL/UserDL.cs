using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class UserDL : IUserDL
    {
        VolunteerContext vrc;
        public UserDL(VolunteerContext vrc)
        {
            this.vrc = vrc;
        }
        //add user
        public async Task<User> AddUser(User user)
        {
            try
            {
                await vrc.Users.AddAsync(user);
                await vrc.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        // get by id
        public async Task<User> GetUserByIdNumber(string id)
        {
            User user = await vrc.Users.Where(s=>s.IdNumber == id).FirstOrDefaultAsync();
            return user;
        }
       
        // log in
        public async Task<User> getUser(string Id, string password)
        {
            User user = await vrc.Users.Where(s => s.IdNumber == Id && s.Password == password).FirstOrDefaultAsync();
            return user;
        }

    }
}
