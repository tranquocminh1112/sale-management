using SaleManagement.Exception;
using SaleManagement.Models;
using SaleManagement.Resources;
using SaleManagement.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace SaleManagement.Services
{
    public class ProductService : IProductService
    {
        private SaleManagementDbContext _context;

        public ProductService(SaleManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(c => c.Id == id && c.Status == ObjectStatus.Active);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            product.Status = ObjectStatus.Active;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            var existing = await GetAsync(product.Id);

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Photo = product.Photo;
            existing.Price = product.Price;
            existing.Quantity = product.Quantity;

            existing.Type = product.Type;
            existing.Supplier = product.Supplier;
            existing.Group = product.Group;
            existing.Company = product.Company;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await GetAsync(id);
            if (existing != null)
            {
                existing.Status = ObjectStatus.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<BaseSearchResponse<Product>> SearchAsync(BasicSearchCriteria criteria)
        {
            var response = new BaseSearchResponse<Product>();

            if (criteria == null)
            {
                criteria = new BasicSearchCriteria();
            }

            var query = _context.Products.Where(v => v.Status == ObjectStatus.Active);


            // filter by name of product
            if (!string.IsNullOrEmpty(criteria.Keyword))
            {
                query = query.Where(v => v.Name.Contains(criteria.Keyword));
            }

            response.Total = await query.CountAsync();

            // paging
            if (criteria.Page.HasValue && criteria.Length.HasValue && criteria.Page.Value > 0 && criteria.Length.Value > 0)
            {
                query = query.Skip(criteria.Length.Value * (criteria.Page.Value - 1)).Take(criteria.Length.Value);
            }


            var products = await query.ToListAsync();

            response.Items = products;

            return response;
        }
    }
}
