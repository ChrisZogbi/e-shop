using System;
using System.Collections.Generic;

namespace eShop.Domain.Aggregates
{
    public class Basket
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public List<Product> Items { get; set; } = new List<Product>();

        public DateTime CreationDate { get; set; }

        public Basket(int userId)
        {
            UserId = userId;
            CreationDate = DateTime.UtcNow;
        }
    }
}
