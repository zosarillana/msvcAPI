using Microsoft.EntityFrameworkCore;
using Restful_API.Model;

namespace Restful_API.Data
{
    public class MarketVisitContext : DbContext
    {
        public MarketVisitContext(DbContextOptions<MarketVisitContext> options) : base(options) { }

        public DbSet<MarketVisit> MarketVisits { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Isr> Isrs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarketVisit>()
                .HasOne(mv => mv.User)              // Navigation property
                .WithMany()                         // Assuming User does not have a collection of MarketVisits
                .HasForeignKey(mv => mv.user_id)   // Foreign key property
                .OnDelete(DeleteBehavior.Restrict); // Configure delete behavior as needed

            modelBuilder.Entity<MarketVisit>()
                .HasOne(mv => mv.Isr)               // Navigation property
                .WithMany()                         // Assuming Isr does not have a collection of MarketVisits
                .HasForeignKey(mv => mv.isr_id)    // Foreign key property
                .OnDelete(DeleteBehavior.Restrict); // Configure delete behavior as needed         

            modelBuilder.Entity<User>()
                .HasKey(u => u.id);

            modelBuilder.Entity<User>()
                .Property(u => u.id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Isr>()
                .HasKey(i => i.id);

            modelBuilder.Entity<Isr>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Pod>()
            .ToTable("Pods")  // Define table name
            .HasKey(p => p.id);
            modelBuilder.Entity<Pod>()
                .Property(p => p.id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Role>()
                .ToTable("Roles")  // Define table name
                .HasKey(r => r.id);
         
            modelBuilder.Entity<Role>()
                .Property(r => r.id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Area>()
            .ToTable("Areas")  // Define table name
            .HasKey(r => r.id);

            modelBuilder.Entity<Area>()
                .Property(r => r.id)
                .ValueGeneratedOnAdd();


        }
    }
}
