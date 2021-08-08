using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.Helpers;
using Shop.Interfaces;
using Shop.Models;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] LoginModel model)
        {
            try
            {
                var user = await _userService.Authenticate(model.Username, model.Password);

                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers(int pageNumber, int pageSize = 4)
        {
            try
            {
                var users = await _userService.GetUsers(pageNumber, pageSize);
                var contentBytes = ExcelHepler<User>.ExportToExcel(users);
                if (contentBytes != null)
                {
                    Response.Clear();
                    Response.Headers.Add("content-disposition", "attachment;filename=Users.xls");
                    Response.ContentType = "application/xls";
                    await Response.Body.WriteAsync(contentBytes);
                    Response.Body.Flush();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
