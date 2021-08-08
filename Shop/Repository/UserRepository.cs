using Dapper;
using Shop.Interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;
        public UserRepository(DapperContext context)
        {
            _context = context;
        }
        public Task<User> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(int userId)
        {
            var query = "select * from Users where Id=@userId";

            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<User>(query, new { userId });
                return user;
            }
        }

        public async Task<IEnumerable<User>> GetUsers(int pageNumber, int pageSize)
        {
            var sp = "spGetUserRowsPerPage";

            using (var connection = _context.CreateConnection())
            {
                var orders = await connection.QueryAsync<User>(sp, new { PageSize = pageSize, PageNumber = pageNumber }, commandType: CommandType.StoredProcedure);
                return orders.ToList();
            }
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var query = "select u.*,r.RoleName from Users u left join Roles r on u.RoleId = r.RoleId";

            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<User>(query);
                return users;
            }
        }
        public Task UpdateUser(int userId, User user)
        {
            throw new NotImplementedException();
        }
    }
}
