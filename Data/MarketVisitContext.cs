
using Microsoft.EntityFrameworkCore;

namespace Restful_API.Data
{
    public class MarketVisitContext : DbContext 
    {
        public MarketVisitContext(DbContextOptions<MarketVisitContext> options) : base(options) { }

        public DbSet<MarketVisit> MarketVisits => Set<MarketVisit>();
    }
}
