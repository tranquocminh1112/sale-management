using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleManagement.Models
{
    public class SaleManagementDbContext : DbContext
    {
        public SaleManagementDbContext(DbContextOptions<SaleManagementDbContext> options) : base(options)
        {
           
        }

        protected SaleManagementDbContext()
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Skip shadow types
                if (entityType.ClrType == null)
                {
                    continue;
                }

                entityType.Relational().TableName = entityType.ClrType.Name;
            }

           // modelBuilder.Entity<BrandTag>().HasKey(t => new { t.BrandId, t.TagId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
