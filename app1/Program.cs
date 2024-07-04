using app1.db.Models;
using System.Diagnostics.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace app1
{
    internal class Program
    {
        public static IConfiguration Configuration { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("________start");

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            //IServiceCollection services = new ServiceCollection();
            //services.AddDbContext<pubsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //using (var pubs = new pubsContext()
            //{
            //    var query = pubs.Authors
            //        .Where(a => a.State == "CA" || a.State == "TN")
            //        .Select(b => b.AuFname + "-" + b.AuLname);

            //    foreach (var item in query.ToList())
            //    {
            //        Console.WriteLine($"{item}");
            //    }
            //}

            Console.WriteLine("________end!");
            Console.ReadLine();
        }
    }
}
