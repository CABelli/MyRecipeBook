using Microsoft.EntityFrameworkCore;
using MyRecipeBook.InfraSqlServer.Model;

namespace MyRecipeBook.InfraSqlServer.ContextSqlServer
{
    public class AppDbContextSqlServer : DbContext
    {
        public AppDbContextSqlServer(DbContextOptions<AppDbContextSqlServer> options) : base(options) { }

        public DbSet<PriceProductClient> PriceProductClient { get; set; }

    }
}
