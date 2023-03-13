﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObjects.Models
{
    public class EShopContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartProduct> CartProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Quick fix to get fixed appsettings.json inside BusinessObjects project
            var realPath = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;
            if (realPath == null)
            {
                throw new Exception("Path to appsettings is incorrect");
            }

            var builder = new ConfigurationBuilder()
                .SetBasePath(realPath)
                .AddJsonFile("BusinessObjects/appsettings.json");

            var connectionString = builder.Build().GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartProduct>()
                .HasOne(cp => cp.Cart)
                .WithMany(c => c.CartProducts)
                .HasForeignKey(bc => bc.CartId);

            modelBuilder.Entity<CartProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(c => c.CartProducts)
                .HasForeignKey(bc => bc.ProductId);
        }
    }
}

