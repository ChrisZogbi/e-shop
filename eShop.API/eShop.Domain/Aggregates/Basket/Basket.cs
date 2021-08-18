using System;
using System.Collections.Generic;

namespace eShop.Domain.Aggregates
{
    public class Basket
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public virtual List<BasketItem> Items { get; set; } = new List<BasketItem>();

        public DateTime CreationDate { get; set; }

        public Basket()
        {
        }

        public Basket(int userId)
        {
            UserId = userId;
            CreationDate = DateTime.UtcNow;
        }

        public decimal GetTotal()
        {
            var total = 0m;
            foreach (var item in Items)
            {
                total += (item.Product.Price * item.Quantity);
            }
            return total;
        }

        public void AddItem(BasketItem item)
        {
            Items.Add(item);
        }
    }
}
