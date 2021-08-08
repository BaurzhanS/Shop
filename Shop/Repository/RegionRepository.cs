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
    public class RegionRepository : IRegionRepository
    {
        private readonly DapperContext _context;

        public RegionRepository(DapperContext context)
        {
            _context = context;
        }
        public Task<Region> CreateRegion(Region order)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRegion(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<Region> GetRegion(int regionId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Region>> GetRegionsByParentId(int parentId, int pageNumber, int pageSize)
        {
            var sp = "spGetRegionsRowsPerPageByParentId";

            using (var connection = _context.CreateConnection())
            {
                var regions = await connection.QueryAsync<Region>(sp, new { ParentId = parentId, PageSize = pageSize, PageNumber = pageNumber }, commandType: CommandType.StoredProcedure);
                return regions.ToList();
            }
        }

        public Task UpdateRegion(int orderId, Region order)
        {
            throw new NotImplementedException();
        }
    }
}
