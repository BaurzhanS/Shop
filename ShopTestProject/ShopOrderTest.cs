using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shop;
using Shop.Controllers;
using Shop.Models;
using Shop.Repository;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShopTestProject
{
    public class ShopOrderTest
    {
        OrderController _orderController;
        OrderService _orderService;
        OrderRepository _orderRepository;
        DapperContext _dapperContext;
        IConfiguration config = InitConfiguration();

        public ShopOrderTest()
        {
            _dapperContext = new DapperContext(config);
            _orderRepository = new OrderRepository(_dapperContext);
            _orderService = new OrderService(_orderRepository);
            _orderController = new OrderController(_orderService);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            int id = 4;
            // Act
            var okResult = _orderController.GetOrder(4);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            int pageNumber = 1;
            int pageSize = 7;
            // Act
            var result = _orderService.GetOrders(pageNumber,pageSize).Result;
            // Assert
            var items = Assert.IsType<List<Order>>(result);
            Assert.Equal(6, items.Count);
        }
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();
            return config;
        }

    }
}
