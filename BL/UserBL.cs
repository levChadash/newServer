using DL;
using Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserBL : IUserBL
    {

        IUserDL _userDl;
        IConfiguration _configuration;
        IPasswordHashHelperBL passwordBL;


        public UserBL(IUserDL userDl, IConfiguration configuration, IPasswordHashHelperBL passwordBL)
        {

            _userDl = userDl;
            _configuration = configuration;
            this.passwordBL = passwordBL;


        }
        //add user
        public async Task<User> AddUser(User user)
        {
            user.Salt = passwordBL.GenerateSalt(8);
            user.Password = passwordBL.HashPassword(user.Password, user.Salt, 1000, 8);
            return await _userDl.AddUser(user);


        } 
        //getById
        public async Task<User> GetUserById(string id)
        {
            return await _userDl.GetUserByIdNumber(id);
        }
       
        public async Task<User> GetUser(string Id, string password)
        {
            User user = await Check(Id, password);
            if (user == null) return null;
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("key").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return WithoutPassword(user);


        }
        public async Task<User> Check(string Id, string password)
        {
            User user = await _userDl.GetUserByIdNumber(Id);
            if (user == null)
            {
                return null;
            }
            string hashPassword = passwordBL.HashPassword(password, user.Salt, 1000, 8);
            if (hashPassword.Equals(user.Password.TrimEnd()))
                return WithoutPassword(user);
            else
                return null;
        }

        public static List<User> WithoutPasswords(List<User> users)
        {
            return users.Select(x => WithoutPassword(x)).ToList();
        }


        public static User WithoutPassword(User user)
        {
            user.Password = null;
            return user;
        }


    }
}
