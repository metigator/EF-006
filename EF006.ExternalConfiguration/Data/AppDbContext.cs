using EF006.ExternalConfiguration.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF006.ExternalConfiguration.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Wallet> Wallets { get; set; } = null!;

        public AppDbContext(DbContextOptions options)
            :base(options)
        {

        }
    }
}
