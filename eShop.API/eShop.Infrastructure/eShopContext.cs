using eShop.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using System;

namespace eShop.Infrastructure
{
    public class eShopContext : DbContext
    {
        public eShopContext(DbContextOptions<eShopContext> options) : base(options)
        {
        }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                new Product(10001, 1, "Lord of the Rings", 10),
                new Product(10002, 1, "The Hobbit", 5),
                new Product(20001, 2, "Game of Thrones", 9),
                new Product(20110, 2, "Breaking Bad", 7)
            );

            //base.OnModelCreating(builder);
        }
    }
}