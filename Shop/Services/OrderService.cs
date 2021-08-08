using ClosedXML.Excel;
using Shop.Interfaces;
using Shop.Models;
using Shop.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class OrderService: IOrderService
    {
        private IOrderRepository repo;
        public OrderService(IOrderRepository orderRepository)
        {
            repo = orderRepository;
        }
        public async Task<IEnumerable<Order>> GetOrders(int pageNumber, int pageSize)
        {
            if(pageNumber == 0)
            {
                pageNumber = 1;
            }
            return await repo.GetOrders(pageNumber, pageSize);
        }
        public async Task<Order> GetOrder(int orderId)
        {
            return await repo.GetOrder(orderId);
        }
        public async Task<Order> CreateOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            var createdOrder = await repo.CreateOrder(order);
            return createdOrder;
        }
        public async Task UpdateOrder(int orderId, Order order)
        {

            await repo.UpdateOrder(orderId, order);
        }
        public async Task DeleteOrder(int orderId)
        {
            await repo.DeleteOrder(orderId);
        }
    }
}
