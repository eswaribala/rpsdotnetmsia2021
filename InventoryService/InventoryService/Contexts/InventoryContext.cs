using InventoryService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Contexts
{
    public class InventoryContext:DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<ProductSupplier> ProductSuppliers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalog>()
       .HasMany(c => c.ProductList)
       .WithOne(p => p.Catalog);
            modelBuilder.Entity<ProductSupplier>()
        .HasKey(ps=> new { ps.ProductId,ps.SupplierId});
            modelBuilder.Entity<ProductSupplier>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductSuppliers)
                .HasForeignKey(ps => ps.ProductId);
            modelBuilder.Entity<ProductSupplier>()
                .HasOne(ps => ps.Supplier)
                .WithMany(s => s.ProductSuppliers)
                .HasForeignKey(ps => ps.SupplierId);


            modelBuilder.Entity<Stock>()
             .HasOne(s => s.Product);


            modelBuilder.Entity<Stock>()
           .HasOne(s => s.Location);

           

        }
        }
    }
