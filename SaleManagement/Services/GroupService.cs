using SaleManagement.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Common.Models;
using System.Text.RegularExpressions;
using SaleManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace SaleManagement.Services
{
    public class GroupService : IGroupService
    {
        private SaleManagementDbContext _context;

        public GroupService(SaleManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Group> GetAsync(int id)
        {
            return await _context.Groups.FirstOrDefaultAsync(c => c.Id == id && c.Status == ObjectStatus.Active);
        }

        public async Task<Models.Group> CreateAsync(Models.Group group)
        {
            group.Status = ObjectStatus.Active;

            _context.Groups.Add(group);
            await _context.SaveChangesAsync();

            return group;
        }

        public async Task UpdateAsync(Models.Group group)
        {
            var existing = await GetAsync(group.Id);

            existing.Name = group.Name;
            existing.Description = group.Description;

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

        public async Task<BaseSearchResponse<Models.Group>> SearchAsync(BasicSearchCriteria criteria)
        {
            var response = new BaseSearchResponse<Models.Group>();

            if (criteria == null)
            {
                criteria = new BasicSearchCriteria();
            }

            var query = _context.Groups.Where(v => v.Status == ObjectStatus.Active);


            // filter by name of group
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


            var group = await query.ToListAsync();

            response.Items = group;

            return response;
        }
    }
}
