using App.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleManagement.ServiceInterfaces
{
    public interface ITypeService
    {
        Task<Models.Type> GetAsync(int id);
        Task<Models.Type> CreateAsync(Models.Type type);
        Task UpdateAsync(Models.Type type);
        Task DeleteAsync(int id);
        Task<BaseSearchResponse<Models.Type>> SearchAsync(BasicSearchCriteria criteria);
    }
}
