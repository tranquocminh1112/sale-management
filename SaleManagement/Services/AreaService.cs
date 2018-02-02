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
    public class AreaService : IAreaService
    {
        private SaleManagementDbContext _context;

        public AreaService(SaleManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Area> GetAsync(int id)
        {
            return await _context.Areas.FirstOrDefaultAsync(c => c.Id == id && c.Status == ObjectStatus.Active);
        }

        public async Task<Area> CreateAsync(Area area)
        {
            area.Status = ObjectStatus.Active;

            _context.Areas.Add(area);
            await _context.SaveChangesAsync();

            return area;
        }

        public async Task UpdateAsync(Area area)
        {
            var existing = await GetAsync(area.Id);

            existing.Name = area.Name;
            existing.Description = area.Description;

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

        public async Task<BaseSearchResponse<Area>> SearchAsync(BasicSearchCriteria criteria)
        {
            var response = new BaseSearchResponse<Area>();

            if (criteria == null)
            {
                criteria = new BasicSearchCriteria();
            }

            var query = _context.Areas.Where(v => v.Status == ObjectStatus.Active);


            // filter by name of area
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


            var area = await query.ToListAsync();

            response.Items = area;

            return response;
        }
    }
}
