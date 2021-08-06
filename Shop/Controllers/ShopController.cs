using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.Models;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private UserService _userService;

        public ShopController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("report")]
        public IActionResult Excel()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                var workbook = new XLWorkbook();

                var SheetNames = new List<string>() { "15-16", "16-17", "17-18", "18-19", "19-20" };

                foreach (var sheetname in SheetNames)
                {
                    var worksheet = workbook.Worksheets.Add(sheetname);

                    worksheet.Cell("A1").Value = sheetname;
                }

                workbook.SaveAs(stream);
                stream.Seek(0, SeekOrigin.Begin);

                return this.File(
                    fileContents: stream.ToArray(),
                    contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",

                    // By setting a file download name the framework will
                    // automatically add the attachment Content-Disposition header
                    fileDownloadName: "ERSheet.xlsx"
                );
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] LoginModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("users")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
    }
}
