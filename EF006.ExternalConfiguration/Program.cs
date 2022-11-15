using EF006.ExternalConfiguration.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System; 
namespace EF006.ExternalConfiguration
{
    class Program
    {
        public static void Main()
        {
            var config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();

            var connectionString = config.GetSection("constr").Value;

            var optionsBuilder = new DbContextOptionsBuilder();

            optionsBuilder.UseSqlServer(connectionString);

            var options = optionsBuilder.Options;

            using (var context = new AppDbContext(options))
            {
                foreach (var wallet in context.Wallets)
                {
                    Console.WriteLine(wallet);
                }
            }
            Console.ReadKey();
        }
    }
}