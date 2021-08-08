using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Helpers;
using Shop.Interfaces;
using Shop.Models;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Чтобы получить эксель файл нужно закомментить [Authorize(Roles = "admin")] и зайти в метод через браузер
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        //[Authorize(Roles = "admin")]
        [HttpGet("orders")]
        public async Task<IActionResult> GetAllOrders(int pageNumber, int pageSize = 4)
        {
            try
            {
                var orders = await _orderService.GetOrders(pageNumber, pageSize);
                //var contentBytes = ExcelHepler<Order>.ExportToExcel(orders);
                //if (contentBytes != null)
                //{
                //    Response.Clear();
                //    Response.Headers.Add("content-disposition", "attachment;filename=Orders.xls");
                //    Response.ContentType = "application/xls";
                //    await Response.Body.WriteAsync(contentBytes);
                //    Response.Body.Flush();
                //}
                
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "user")]
        [HttpGet("order/{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            try
            {
                var order = await _orderService.GetOrder(id);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [Authorize(Roles = "user")]
        [HttpPost("createOrder")]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var createdOrder = await _orderService.CreateOrder(order);
                return Ok(createdOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [Authorize(Roles = "admin")]
        [HttpPost("updateOrder/{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var orderInDb = await _orderService.GetOrder(id);
                if (orderInDb == null)
                    return NotFound();

                await _orderService.UpdateOrder(id, order);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpGet("deleteOrder/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var orderInDb = await _orderService.GetOrder(id);
                if (orderInDb == null)
                    return NotFound();

                await _orderService.DeleteOrder(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
