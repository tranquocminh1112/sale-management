using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SaleManagement.Models
{
    public class SaleManagementDbContext : DbContext
    {
        public SaleManagementDbContext(DbContextOptions<SaleManagementDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Transporter> Transporters { get; set; }
        
        public DbSet<CustomerTransporter> CustomerTransporters { get; set; }

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

           modelBuilder.Entity<CustomerTransporter>().HasKey(t => new { t.CustomerId, t.TransporterId });

            base.OnModelCreating(modelBuilder);
        }

        public static void UpdateDatabase(SaleManagementDbContext context)
        {
            context.Database.Migrate();
        }

        /// <summary>
        /// Auto record create and modify time
        /// </summary>
        private void UpdateTimeTracker()
        {
            var currentTime = DateTime.Now;

            //Find all Entities that are Added/Modified that inherit from my EntityBase
            var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Metadata.FindProperty("CreatedAt") != null)
                    {
                        entry.Property("CreatedAt").CurrentValue = currentTime;
                    }
                }
                else
                {
                    if (entry.Metadata.FindProperty("ModifiedAt") != null)
                    {
                        entry.Property("ModifiedAt").CurrentValue = currentTime;
                    }
                }
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateTimeTracker();

            return base.SaveChangesAsync();
        }

        public override int SaveChanges()
        {
            UpdateTimeTracker();

            return base.SaveChanges();
        }
    }
}
