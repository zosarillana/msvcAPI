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
    }
}