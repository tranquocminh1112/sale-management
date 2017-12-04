using App.Common.Models;
using SaleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleManagement.ServiceInterfaces
{
    public interface IAreaService
    {
        Task<Area> GetAsync(int id);
        Task<Area> CreateAsync(Area area);
        Task UpdateAsync(Area area);
        Task DeleteAsync(int id);
        Task<BaseSearchResponse<Area>> SearchAsync(BasicSearchCriteria criteria);
    }
}
