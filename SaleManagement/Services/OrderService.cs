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
    public class OrderService : IOrderService
    {
        private SaleManagementDbContext _context;

        public OrderService(SaleManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetAsync(string id)
        {
            return await _context.Orders.FirstOrDefaultAsync(c => c.Id == id && c.Status == ObjectStatus.Active);
        }

        public async Task<Order> CreateAsync(Order order)
        {
            order.Status = ObjectStatus.Active;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task UpdateAsync(Order order)
        {
            var existing = await GetAsync(order.Id);

            existing.Note = order.Note;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var existing = await GetAsync(id);
            if (existing != null)
            {
                existing.Status = ObjectStatus.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<BaseSearchResponse<Order>> SearchAsync(BasicSearchCriteria criteria)
        {
            var response = new BaseSearchResponse<Order>();

            if (criteria == null)
            {
                criteria = new BasicSearchCriteria();
            }

            var query = _context.Orders.Where(v => v.Status == ObjectStatus.Active);


            // filter by id of order
            if (!string.IsNullOrEmpty(criteria.Keyword))
            {
                query = query.Where(v => v.Id.Contains(criteria.Keyword));
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
