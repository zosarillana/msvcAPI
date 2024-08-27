using Microsoft.EntityFrameworkCore;

namespace Restful_API.Data
{
    public class MarketVisitContext : DbContext
    {
        public MarketVisitContext(DbContextOptions<MarketVisitContext> options) : base(options) { }

        public DbSet<MarketVisit> MarketVisits { get; set; }  // Fix this line
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarketVisit>()
                .HasOne(mv => mv.User)              // Navigation property
                .WithMany()                         // Assuming User does not have a collection of MarketVisits
                .HasForeignKey(mv => mv.user_id)   // Foreign key property
                .OnDelete(DeleteBehavior.Restrict); // Configure delete behavior as needed

            base.OnModelCreating(modelBuilder);
        }
    }
}
