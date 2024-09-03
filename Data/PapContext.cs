using Microsoft.EntityFrameworkCore;
using Restful_API.Model;

namespace Restful_API.Data
{
    public class PapContext : DbContext
    {
        public PapContext(DbContextOptions<PapContext> options) : base(options) { }

        public DbSet<Pap> Paps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pap>()
                .ToTable("Paps")
                .HasKey(p => p.id);

            modelBuilder.Entity<Pap>()
                .Property(p => p.id)
                .ValueGeneratedOnAdd();
        }
    }
}
