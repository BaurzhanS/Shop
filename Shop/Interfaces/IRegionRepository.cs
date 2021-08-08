using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    public interface IRegionRepository
    {
        public Task<IEnumerable<Region>> GetRegionsByParentId(int parentId, int pageNumber, int pageSize);
        public Task<Region> GetRegion(int regionId);
        public Task<Region> CreateRegion(Region order);
        public Task UpdateRegion(int orderId, Region order);
        public Task DeleteRegion(int orderId);
    }
}
