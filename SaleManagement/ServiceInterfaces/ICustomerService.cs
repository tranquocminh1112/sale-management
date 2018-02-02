using App.Common.Models;
using SaleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleManagement.ServiceInterfaces
{
    public interface ICustomerService
    {
        Task<Customer> GetAsync(int id, bool includeChildren = false);
        Task<Customer> CreateAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int id);
        Task<BaseSearchResponse<Customer>> SearchAsync(BasicSearchCriteria criteria);
    }
}
