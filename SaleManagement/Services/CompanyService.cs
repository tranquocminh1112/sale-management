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
    public class CompanyService : ICompanyService
    {
        private SaleManagementDbContext _context;

        public CompanyService(SaleManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Company> GetAsync(int id)
        {
            return await _context.Companies.FirstOrDefaultAsync(c => c.Id == id && c.Status == ObjectStatus.Active);
        }

        public async Task<Company> CreateAsync(Company company)
        {
            company.Status = ObjectStatus.Active;

            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return company;
        }

        public async Task UpdateAsync(Company company)
        {
            var existing = await GetAsync(company.Id);

            existing.Name = company.Name;
            existing.Description = company.Description;

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

        public async Task<BaseSearchResponse<Company>> SearchAsync(BasicSearchCriteria criteria)
        {
            var response = new BaseSearchResponse<Company>();

            if (criteria == null)
            {
                criteria = new BasicSearchCriteria();
            }

            var query = _context.Companies.Where(v => v.Status == ObjectStatus.Active);


            // filter by name of company
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


            var company = await query.ToListAsync();

            response.Items = company;

            return response;
        }
    }
}
