using SaleManagement.Exception;
using SaleManagement.Models;
using SaleManagement.Resources;
using SaleManagement.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Common.Models;

namespace SaleManagement.Services
{
    public class ProductService : IProductService
    {
        private readonly SaleManagementDbContext _context;

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return product;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseSearchResponse<Product>> SearchAsync(BasicSearchCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
