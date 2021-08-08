using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    public interface IRegionService
    {
        public Task<IEnumerable<Region>> GetRegionsByParentId(int parentId, int pageNumber, int pageSize);
    }
}
