using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEF_Code
{
    public class PubsDbContext: DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Sale> Sales{ get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Pubs;User Id=sa;Password=sasa;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // tables
            //modelBuilder.Entity<Store>().ToTable("stores");
            //modelBuilder.Entity<Title>().ToTable("titles");
            //modelBuilder.Entity<Sale>().ToTable("sales");

            // keys
            modelBuilder.Entity<Store>().HasKey(x => x.stor_id);
            modelBuilder.Entity<Title>().HasKey(x => x.title_id);
            modelBuilder.Entity<Sale>().HasKey(x => new { x.stor_id, x.ord_num, x.title_id });
            modelBuilder.Entity<Author>().HasKey(x => x.au_id);
        }
    }
}
