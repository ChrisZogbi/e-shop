using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Aggregates
{
    public class BasketItem
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }

        public BasketItem(int basketId, int productId, int quantity)
        {
            BasketId = basketId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
