using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUsers(int pageNumber, int pageSize);
        public Task<User> GetUser(int userId);
        public Task<User> CreateUser(User user);
        public Task UpdateUser(int userId, User user);
        public Task DeleteUser(int userId);
        public Task<IEnumerable<User>> GetAllUsers();
    }
}
