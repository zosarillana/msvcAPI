using Microsoft.EntityFrameworkCore;
using Restful_API.Model;

namespace Restful_API.Data
{
    public class PodContext : DbContext
    {
        public PodContext(DbContextOptions<PodContext> options) : base(options) { }

        public DbSet<Pod> Pods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pod>()
                .ToTable("Pods")
                .HasKey(p => p.id);

            modelBuilder.Entity<Pod>()
                .Property(p => p.id)
                .ValueGeneratedOnAdd();
        }
    }
}
