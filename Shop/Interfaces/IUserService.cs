using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    public interface IUserService
    {
        public Task<User> Authenticate(string username, string password);
        public Task<IEnumerable<User>> GetUsers(int pageNumber, int pageSize);
        public Task<User> GetUser(int Id);
    }
}
