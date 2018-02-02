using App.Common.Models;
using SaleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleManagement.ServiceInterfaces
{
    public interface IOrderService
    {
        Task<Order> GetAsync(string id);
        Task<Order> CreateAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(string id);
        Task<BaseSearchResponse<Order>> SearchAsync(BasicSearchCriteria criteria);
    }
}
