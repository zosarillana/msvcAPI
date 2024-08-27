using Microsoft.EntityFrameworkCore;
using Restful_API.Model;

namespace Restful_API.Data
{
    public class IsrContext : DbContext
    {
        public IsrContext(DbContextOptions<IsrContext> options) : base(options) { }

        public DbSet<Isr> Isrs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Isr>()
                .HasKey(i => i.id);

            modelBuilder.Entity<Isr>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();
        }
    }
}
