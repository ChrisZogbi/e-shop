using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Aggregates
{
    public interface IBasketRepository
    {
        Task<Basket> GetUserBasket(int userId);
        Task AddItemToBasket(BasketItem basketItem);
        Task<Basket> CreateBasket(Basket basket);
    }
}
