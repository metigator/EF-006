using EF006.UsingDependancyInjection.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF006.UsingDependancyInjection.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Wallet> Wallets { get; set; } = null!;

        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
