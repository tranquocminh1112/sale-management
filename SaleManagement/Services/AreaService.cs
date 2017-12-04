using SaleManagement.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Common.Models;
using SaleManagement.Models;

namespace SaleManagement.Services
{
    public class AreaService : IAreaService
    {
        public Task<Area> CreateAsync(Area area)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Area> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseSearchResponse<Area>> SearchAsync(BasicSearchCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Area area)
        {
            throw new NotImplementedException();
        }
    }
}
