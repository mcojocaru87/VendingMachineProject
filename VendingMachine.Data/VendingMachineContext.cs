using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using VendingMachine.Entity;

namespace VendingMachine.Data
{
    public partial class VendingMachineContext : DbContext
    {
        public VendingMachineContext()
            : base("name=VendingMachineContext") { }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tray> Trays { get; set; }
        public DbSet<TrayProduct> TrayProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>().ToTable("Inventory");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Tray>().ToTable("Tray");
            modelBuilder.Entity<TrayProduct>().ToTable("TrayProduct");
        }
    }
}
