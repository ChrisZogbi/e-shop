namespace eShop.Domain.Aggregates
{
    public class BasketItem
    {
        public int Id { get; set; }
        private int _basketId { get; }
        public Basket Basket { get; set; }
        private int _productId { get; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }

        public BasketItem() { }

        public BasketItem(Basket basket, Product product, int quantity)
        {
            Basket = basket;
            Product = product;
            Quantity = quantity;

            _basketId = basket.Id;
            _productId = product.Id;
        }
    }
}
