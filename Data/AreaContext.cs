using Microsoft.EntityFrameworkCore;
using Restful_API.Model;

namespace Restful_API.Data
{
    public class AreaContext : DbContext
    {
        public AreaContext(DbContextOptions<AreaContext> options) : base(options)
        {
        }

        public DbSet<Area> Areas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
                .ToTable("Areas")  // Table name in database
                .HasKey(i => i.id);

            modelBuilder.Entity<Area>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();
        }

    }

}
