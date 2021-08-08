using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    public interface IOrderService
    {
        public Task<IEnumerable<Order>> GetOrders(int pageNumber, int pageSize);
        public Task<Order> GetOrder(int orderId);
        public Task<Order> CreateOrder(Order order);
        public Task UpdateOrder(int orderId, Order order);
        public Task DeleteOrder(int orderId);
    }
}
