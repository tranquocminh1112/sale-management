using App.Common.Models;
using SaleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleManagement.ServiceInterfaces
{
    public interface ICompanyService
    {
        Task<Company> GetAsync(int id);
        Task<Company> CreateAsync(Company company);
        Task UpdateAsync(Company company);
        Task DeleteAsync(int id);
        Task<BaseSearchResponse<Company>> SearchAsync(BasicSearchCriteria criteria);
    }
}
