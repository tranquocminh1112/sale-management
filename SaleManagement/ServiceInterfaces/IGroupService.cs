using App.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SaleManagement.Models;

namespace SaleManagement.ServiceInterfaces
{
    public interface IGroupService
    {
        Task<Models.Group> GetAsync(int id);
        Task<Models.Group> CreateAsync(Models.Group group);
        Task UpdateAsync(Models.Group group);
        Task DeleteAsync(int id);
        Task<BaseSearchResponse<Models.Group>> SearchAsync(BasicSearchCriteria criteria);
    }
}
