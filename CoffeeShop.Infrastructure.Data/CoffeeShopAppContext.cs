using CoffeeShop.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Infrastructure.Data
{
    public class CoffeeShopAppContext : DbContext
    {
        public CoffeeShopAppContext(DbContextOptions<CoffeeShopAppContext> opt)
            : base(opt) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Client)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Client)
                .WithMany(c => c.Orders)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.OrderedItem);
        }


        public DbSet<Client> Clients { get; set; }
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
