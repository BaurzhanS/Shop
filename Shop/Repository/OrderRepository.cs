using Dapper;
using Microsoft.Extensions.Configuration;
using Shop.Interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Repository
{
    public class OrderRepository: IOrderRepository
    {
        private readonly DapperContext _context;

        public OrderRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrders(int pageNumber, int pageSize)
        {
            var sp = "spGetOrderRowsPerPage";

            using (var connection = _context.CreateConnection())
            {
                var orders = await connection.QueryAsync<Order>(sp, new { PageSize = pageSize, PageNumber = pageNumber },commandType: CommandType.StoredProcedure);
                return orders.ToList();
            }
        }

        public async Task<Order> GetOrder(int orderId)
        {
            var query = "select * from orders where orderId=@orderId";

            using (var connection = _context.CreateConnection())
            {
                var order = await connection.QuerySingleOrDefaultAsync<Order>(query,new { orderId});
                return order;
            }
        }
        public async Task<Order> CreateOrder(Order order)
        {
            var query = "INSERT INTO Orders (OrderDate, DeliveryRegionId, OrderPrice)" +
                " VALUES (@OrderDate, @DeliveryRegionId, @OrderPrice)" + 
        "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("OrderDate", order.OrderDate, DbType.String);
            parameters.Add("DeliveryRegionId", order.DeliveryRegionId, DbType.Int32);
            parameters.Add("OrderPrice", order.OrderPrice, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdOrder = new Order
                {
                    OrderId = id,
                    DeliveryRegionId = order.DeliveryRegionId,
                    OrderDate = order.OrderDate,
                    OrderPrice = order.OrderPrice
                };
                return createdOrder;
            }
        }
        public async Task UpdateOrder(int orderId, Order order)
        {
            var query = "UPDATE Orders SET OrderDate=@OrderDate, DeliveryRegionId=@DeliveryRegionId, OrderPrice=@OrderPrice" +
                "       WHERE OrderId=@orderId";

            var parameters = new DynamicParameters();
            parameters.Add("OrderId", orderId, DbType.Int32);
            parameters.Add("OrderDate", order.OrderDate, DbType.String);
            parameters.Add("DeliveryRegionId", order.DeliveryRegionId, DbType.Int32);
            parameters.Add("OrderPrice", order.OrderPrice, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }
        public async Task DeleteOrder(int orderId)
        {
            var query = "DELETE FROM Orders WHERE OrderId = @orderId";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { orderId });
            }
        }
    }
}
