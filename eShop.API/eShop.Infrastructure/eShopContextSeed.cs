using eShop.Domain.Aggregates;
using eShop.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OhpenChallenge.Infrastructre
{
    public class eShopContextSeed
    {
        public async Task SeedAsync(eShopContext context)
        {
            using (context)
            {
                if (!context.Products.Any())
                {
                    context.Products.AddRange(GetPredefinedProducts());
                }
            }
        }

        private IEnumerable<Product> GetPredefinedProducts()
        {
            return new List<Product> {
                new Product(10001, 1,"Lord of the Rings", 10),
                new Product(10002, 1,"The Hobbit", 5),
                new Product(20001, 2,"Game of Thrones", 9),
                new Product(20110, 2,"Breaking Bad", 7),
            };
        }
    }
}
