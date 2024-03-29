﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Helpers;
using Shop.Interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        /// <summary>
        /// Чтобы получить эксель файл нужно закомментить [Authorize(Roles = "user")] и зайти в метод через браузер
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Authorize(Roles = "user")]
        [HttpGet("regions/{parentId}")]
        public async Task<IActionResult> GetRegionsByParentId(int parentId, int pageNumber, int pageSize = 10)
        {
            try
            {
                var regions = await _regionService.GetRegionsByParentId(parentId, pageNumber, pageSize);
                var contentBytes = ExcelHepler<Region>.ExportToExcel(regions);
                if (contentBytes != null)
                {
                    Response.Clear();
                    Response.Headers.Add("content-disposition", "attachment;filename=Regions.xls");
                    Response.ContentType = "application/xls";
                    await Response.Body.WriteAsync(contentBytes);
                    Response.Body.Flush();
                }

                return Ok(regions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
