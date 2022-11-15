using EF006.DbContextAndConcurrency.Data;
using EF006.DbContextAndConcurrency.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace EF006.DbContextAndConcurrency
{
    class Program
    {
        static AppDbContext context;
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

            context = serviceProvider.GetRequiredService<AppDbContext>();


            var tasks = new[]
            {
                Task.Factory.StartNew(() => Job1()),
                Task.Factory.StartNew(() => Job2())
            };

            Task.WhenAll(tasks).ContinueWith(t => {
                Console.WriteLine("Job1 & Job2 executed concurrently!");
            });

            Console.ReadKey();
        }

        static async Task Job1()
        {
           
            var w1 = new Wallet { Holder = "Jasem", Balance = 1000m };

            context.Wallets.Add(w1);

            await context.SaveChangesAsync();
        }

        static async Task Job2()
        {
           
            var w2 = new Wallet { Holder = "Rema", Balance = 900m };

            context.Wallets.Add(w2);

            await context.SaveChangesAsync();

        }
    }
}