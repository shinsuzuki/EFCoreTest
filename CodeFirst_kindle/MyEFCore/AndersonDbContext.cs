using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst_kindle.MyEFCore
{
    public class AndersonDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MyData> MyDatas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = "SSTPX13G4";
            builder.InitialCatalog = "AndersonM";
            builder.IntegratedSecurity = true;
            builder.Encrypt = false;    // 信頼されていない機関によって証明書チェーンが発行されました_のエラー対応

            optionsBuilder.UseSqlServer(builder.ConnectionString)
                .LogTo(msg => System.Diagnostics.Debug.WriteLine(msg),  // ログを出力、フィルター
                    new[] { DbLoggerCategory.Database.Command.Name },
                    Microsoft.Extensions.Logging.LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //---------------------------------------- 
            // Product
            //----------------------------------------
            modelBuilder.Entity<Product>()
                .Ignore(x => x.TempId);

            modelBuilder.Entity<Product>()
                .Property(x => x.ProductName).HasMaxLength(255);


            //---------------------------------------- 
            // Customer
            //----------------------------------------
            //modelBuilder.Entity<Customer>()
            //    .Property(x => x.CustomerId).ValueGeneratedNever();   // Identityにしない

            //---------------------------------------- 
            // MyData
            //----------------------------------------
            modelBuilder.Entity<MyData>().HasKey(x => new { x.Code, x.Name });



        }
    }
}
