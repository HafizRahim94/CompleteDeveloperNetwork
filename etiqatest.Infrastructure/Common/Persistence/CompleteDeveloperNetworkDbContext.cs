using Microsoft.EntityFrameworkCore;
using etiqatest.Domain.Users;
using etiqatest.Domain.Common;
using etiqatest.Application.Common.Interfaces;

namespace etiqatest.Infrastructure.Common.Persistence
{
    public class CompleteDeveloperNetworkDbContext : DbContext
    {
        private string _currentUserId;

        public CompleteDeveloperNetworkDbContext()
        {
        }

        public CompleteDeveloperNetworkDbContext(DbContextOptions<CompleteDeveloperNetworkDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Skillset> Skillsets { get; set; }

        // Method to set the current user ID
        public void SetCurrentUserId(string userId)
        {
            _currentUserId = userId;

        }
        public override int SaveChanges()
        {
            // Override SaveChanges to set audit properties
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is AuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (AuditableEntity)entry.Entity;
                var now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = now;
                    entity.CreatedBy = _currentUserId; // Replace with actual user
                }

                entity.LastUpdatedAt = now;
                entity.UpdatedBy = _currentUserId; // Replace with actual user
            }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Override SaveChanges to set audit properties
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is AuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (AuditableEntity)entry.Entity;
                var now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = now;
                    entity.CreatedBy = _currentUserId; // Replace with actual user
                }

                entity.LastUpdatedAt = now;
                entity.UpdatedBy = _currentUserId; // Replace with actual user
            }

            return base.SaveChangesAsync();
        }
    }
}