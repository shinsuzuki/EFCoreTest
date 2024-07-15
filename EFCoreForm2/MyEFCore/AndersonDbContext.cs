using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EFCoreForm2.MyEFCore
{
    public class AndersonDbContext: DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = "SSTPX13G4";
            builder.InitialCatalog = "AndersonA";
            builder.IntegratedSecurity = true;
            builder.Encrypt = false;    // 信頼されていない機関によって証明書チェーンが発行されました_のエラー対応

            optionsBuilder.UseSqlServer(builder.ConnectionString)
                .LogTo(msg => System.Diagnostics.Debug.WriteLine(msg),  // ログを出力、フィルター
                    new[] { DbLoggerCategory.Database.Command.Name }, 
                    Microsoft.Extensions.Logging.LogLevel.Information ); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>()
                .ToTable("Product")
                .HasKey(p => p.ProductId);

            modelBuilder.Entity<Order>()
                .ToTable("Order");


            modelBuilder.Entity<OrderItem>().HasKey(oi => new 
            { 
                oi.OrderId, oi.ProductId 
            });


            modelBuilder.Entity<OrderItem>()
                .ToTable("OrderItem")
                .HasOne(oi => oi.Order)                 // このプロパティからデータを一つだけ持ちます
                .WithMany(oi => oi.OrderItems)          // Order側からみたらN件
                .HasForeignKey(oi => oi.OrderId)        // 外部キー
                .IsRequired(false)                      // 外部結合とするため必須にしない
                .HasConstraintName("FK_OrderItem_Order");

            modelBuilder.Entity<OrderItem>()
                .ToTable("OrderItem")
                .HasOne(oi => oi.Product)               // このプロパティからデータを一つだけ持ちます
                .WithMany(oi => oi.OrderItems)          // Product側からみたらN件
                .HasForeignKey(oi => oi.ProductId)      // 外部キー
                .IsRequired(false)                      // 外部結合とするため必須にしない
                .HasConstraintName("FK_OrderItem_Product");
        }
    }
}
