using Microsoft.EntityFrameworkCore;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Data
{
    public class ProductShopContext : DbContext
    {
        public ProductShopContext() { }

        public ProductShopContext(DbContextOptions options)
                : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>()
                .HasKey(e => new { e.CategoryId, e.ProductId });

            modelBuilder.Entity<User>()
                .HasMany(u => u.BoughtProducts)
                .WithOne(u => u.Buyer)
                .HasForeignKey(u => u.BuyerId);

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Age)
                    .IsRequired(false);
            });
                

            modelBuilder.Entity<User>()
                .HasMany(u => u.SoldProducts)
                .WithOne(u => u.Seller)
                .HasForeignKey(u => u.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.ProductId);
        }
    }
}
