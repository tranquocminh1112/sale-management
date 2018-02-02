using SaleManagement.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Common.Models;
using SaleManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace SaleManagement.Services
{
    public class CategoryService : ICategoryService
    {
        private SaleManagementDbContext _context;

        public CategoryService(SaleManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Category> GetAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id && c.Status == ObjectStatus.Active);
        }

        public async Task<Category> CreateAsync(Category category)
        {
            category.Status = ObjectStatus.Active;

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task UpdateAsync(Category category)
        {
            var existing = await GetAsync(category.Id);

            existing.Name = category.Name;
            existing.Description = category.Description;

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

        public async Task<BaseSearchResponse<Category>> SearchAsync(BasicSearchCriteria criteria)
        {
            var response = new BaseSearchResponse<Category>();

            if (criteria == null)
            {
                criteria = new BasicSearchCriteria();
            }

            var query = _context.Categories.Where(v => v.Status == ObjectStatus.Active);


            // filter by name of category
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


            var category = await query.ToListAsync();

            response.Items = category;

            return response;
        }
    }
}
