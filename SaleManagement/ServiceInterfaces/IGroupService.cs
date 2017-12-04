using App.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SaleManagement.ServiceInterfaces
{
    public interface IGroupService
    {
        Task<Group> GetAsync(int id);
        Task<Group> CreateAsync(Group group);
        Task UpdateAsync(Group group);
        Task DeleteAsync(int id);
        Task<BaseSearchResponse<Group>> SearchAsync(BasicSearchCriteria criteria);
    }
}
