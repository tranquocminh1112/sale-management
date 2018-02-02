using SaleManagement.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Common.Models;
using SaleManagement.Models;
using Microsoft.EntityFrameworkCore;
using SaleManagement.Exception;
using SaleManagement.Resources;
using SaleManagement.Models.ViewModels;
using SaleManagement.Adapters;

namespace SaleManagement.Services
{
    public class CustomerService : ICustomerService
    {
        private SaleManagementDbContext _context;

        public CustomerService(SaleManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetAsync(int id, bool includeChildren = false)
        {
            if (includeChildren)
            {
                return await IncludeChildren().FirstOrDefaultAsync(c => c.Id == id && c.Status == ObjectStatus.Active);
            }
            else
            {
                return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id && c.Status == ObjectStatus.Active);
            }
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            customer.Status = ObjectStatus.Active;

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task UpdateAsync(Customer customer)
        {
            var existing = await GetAsync(customer.Id,true);

            existing.Name = customer.Name;
            existing.Description = customer.Description;
            existing.MainContactNumber = customer.MainContactNumber;
            existing.MainContactPerson = customer.MainContactPerson;
            existing.SubContactNumber = customer.SubContactNumber;
            existing.SubContactPerson = customer.SubContactPerson;

            existing.Debt = customer.Debt;
            existing.DebtOrder = customer.DebtOrder;

            existing.Credit = customer.Credit;
            existing.CreditOrder = customer.CreditOrder;

            existing.Area = customer.Area;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await GetAsync(id);
            if(existing != null)
            {
                existing.Status = ObjectStatus.Deleted;
                await _context.SaveChangesAsync();
            } 
        }

        public async Task<BaseSearchResponse<Customer>> SearchAsync(BasicSearchCriteria criteria)
        {
            var response = new BaseSearchResponse<Customer>();

            if (criteria == null)
            {
                criteria = new BasicSearchCriteria();
            }

            var query = _context.Customers.Where(v => v.Status == ObjectStatus.Active);


            // filter by name of customer
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


            var customers = await query.ToListAsync();

            response.Items = customers;

            return response;
        }

        private IQueryable<Customer> IncludeChildren()
        {
            return _context.Customers
                .Include(c => c.DebtOrder)
                .Include(c => c.CreditOrder)
                .Include(c => c.Area)
                .Include(c => c.Transporters)
                .Include(c => c.Orders);
        }
    }
}
