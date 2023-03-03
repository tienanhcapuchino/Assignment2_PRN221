using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Configuration;
using SignalRAssignment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAssignment.DataContext
{
    public class ShoppingDbContext : DbContext
    {
        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options) : base(options)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShoppingDbContext, MigrationConfiguration>());
        }
        //public ShoppingDbContext() : base("SchoolDB")
        //{ 

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("ShoppingStr"));
            }
        }
        public ShoppingDbContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new SuppliersConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new OrdersConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());
            modelBuilder.ApplyConfiguration(new CustomersConfiguration());
        }
        #region Entity
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        #endregion
    }
}
