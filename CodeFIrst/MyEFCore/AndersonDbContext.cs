using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;

namespace CodeFirst.MyEFCore
{
    public class AndersonDbContext : DbContext
        {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Data Source=localhost;Initial Catalog=AndersonM;Persist Security Info=True;User ID=sa;Password=sasa;Encrypt=True;TrustServerCertificate=True;");
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<Customer> Customers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.ProductName).HasMaxLength(255);
            modelBuilder.Entity<Product>().Ignore(x => x.TempId);

            // Identityを設定しない
            modelBuilder.Entity<Customer>().Property(x => x.CustomerId).ValueGeneratedNever();

            // 主キー制御(主キーを持たせない)
            //modelBuilder.Entity<MyData>().HasNoKey();
            // 主キー制御(主キーを持たせせる)
            //modelBuilder.Entity<MyData>().HasKey(x => x.Code);
            // 主キー制御(複合キーを持たせせる)
            modelBuilder.Entity<MyData>().HasKey(x => new { x.Code, x.Name });
        }
    }
}



