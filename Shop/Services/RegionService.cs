using Shop.Interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class RegionService : IRegionService
    {
        private IRegionRepository repo;
        public RegionService(IRegionRepository regionRepository)
        {
            repo = regionRepository;
        }
        public async Task<IEnumerable<Region>> GetRegionsByParentId(int parentId, int pageNumber, int pageSize)
        {
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            return await repo.GetRegionsByParentId(parentId, pageNumber, pageSize);
        }
    }
}
