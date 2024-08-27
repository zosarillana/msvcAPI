using Microsoft.EntityFrameworkCore;
using Restful_API.Model;

namespace Restful_API.Data
{
    public class RoleContext : DbContext
    {
        public RoleContext(DbContextOptions<RoleContext> options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .ToTable("Roles")  // Table name in database
                .HasKey(i => i.id);

            modelBuilder.Entity<Role>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();
        }
    }
}
