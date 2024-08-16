using Microsoft.EntityFrameworkCore;
using Restful_API.Model;

namespace Restful_API.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.id);  // Define `id` as the primary key

            modelBuilder.Entity<User>()
                .Property(u => u.id)
                .ValueGeneratedOnAdd();  // Enable auto-increment for the `id` column

            modelBuilder.Entity<User>()
                .HasIndex(u => u.abfi_id)
                .IsUnique();  // Ensure `abfi_id` is unique
        }
    }
}
