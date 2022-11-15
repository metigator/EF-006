using EF006.UsingDependancyInjection.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace EF006.UsingDependancyInjection
{
    class Program
    {
        public static void Main()
        {
            var config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();

            var connectionString = config.GetSection("constr").Value;

            var services = new ServiceCollection();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString)
            );

            IServiceProvider serviceProvider = services.BuildServiceProvider();


            using (var context = serviceProvider.GetService<AppDbContext>())
            {
                foreach (var wallet in context!.Wallets)
                {
                    Console.WriteLine(wallet);
                }
            }
            Console.ReadKey();
        }
    }
}