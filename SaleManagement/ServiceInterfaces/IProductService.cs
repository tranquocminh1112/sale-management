using App.Common.Models;
using SaleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleManagement.ServiceInterfaces
{
    public interface IProductService
    {
        Task<Product> GetAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
        Task<BaseSearchResponse<Product>> SearchAsync(BasicSearchCriteria criteria);
    }
}
