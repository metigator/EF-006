using EF006.InternalConfiguration.Data;
using System;
namespace EF006.InternalConfiguration
{
    class Program
    {
        public static void Main()
        {
            using (var context = new AppDbContext())
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