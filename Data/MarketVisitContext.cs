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
                .HasOne(mv => mv.User)
                .WithMany() // Adjust if User has a collection of MarketVisits
                .HasForeignKey(mv => mv.user_id)
                .OnDelete(DeleteBehavior.Restrict); // Adjust as needed

            modelBuilder.Entity<MarketVisit>()
                .HasOne(mv => mv.Area)
                .WithMany() // Adjust if Area has a collection of MarketVisits
                .HasForeignKey(mv => mv.area_id)
                .OnDelete(DeleteBehavior.Restrict); // Adjust as needed

            modelBuilder.Entity<MarketVisit>()
                .HasOne(mv => mv.Isr)
                .WithMany() // Adjust if Isr has a collection of MarketVisits
                .HasForeignKey(mv => mv.isr_id)
                .OnDelete(DeleteBehavior.Restrict); // Adjust as needed

            modelBuilder.Entity<MarketVisit>()
                .HasOne(mv => mv.Pod)
                .WithMany() // Adjust if Pod has a collection of MarketVisits
                .HasForeignKey(mv => mv.pod_id)
                .OnDelete(DeleteBehavior.Restrict); // Adjust as needed

            modelBuilder.Entity<MarketVisit>()
                .HasOne(mv => mv.Pap)
                .WithMany() // Adjust if Pap has a collection of MarketVisits
                .HasForeignKey(mv => mv.pap_id)
                .OnDelete(DeleteBehavior.Restrict); // Adjust as needed

            // Configure entities
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
                .ToTable("Pods")
                .HasKey(p => p.id);

            modelBuilder.Entity<Pod>()
                .Property(p => p.id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Pap>()
                .ToTable("Paps")
                .HasKey(p => p.id);

            modelBuilder.Entity<Pap>()
                .Property(p => p.id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Area>()
                .ToTable("Areas")
                .HasKey(a => a.id);

            modelBuilder.Entity<Area>()
                .Property(a => a.id)
                .ValueGeneratedOnAdd();
        }
    }
}
