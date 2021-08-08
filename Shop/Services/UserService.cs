using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shop.Helpers;
using Shop.Interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class UserService: IUserService
    {
        private readonly AppSettings _appSettings;
        private IUserRepository repo;
        public UserService(IUserRepository repository, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            repo = repository;
        }
        public async Task<User> Authenticate(string username, string password)
        {
            var users = await repo.GetAllUsers();
            var user = users.FirstOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.RoleName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }
        public async Task<IEnumerable<User>> GetUsers(int pageNumber, int pageSize)
        {
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            return await repo.GetUsers(pageNumber, pageSize);
        }
        public async Task<User> GetUser(int Id)
        {
            return await repo.GetUser(Id);
        }
    }
}
