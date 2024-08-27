using Microsoft.EntityFrameworkCore;
using Restful_API.Model;

namespace Restful_API.Data
{
    public class IsrContext : DbContext
    {
        public IsrContext(DbContextOptions<RoleContext> options) : base(options)
        {
        }

        public DbSet<Isr> Isrs { get; set; }
    }
}