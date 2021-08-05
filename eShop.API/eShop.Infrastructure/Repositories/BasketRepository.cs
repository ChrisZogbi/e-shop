using eShop.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly eShopContext _db;

        public BasketRepository(eShopContext db)
        {
            _db = db;
        }

        public async Task AddItemToBasket(BasketItem basketItem)
        {
            _db.BasketItems.Add(basketItem);
            await _db.SaveChangesAsync();
        }

        public async Task<Basket> CreateBasket(Basket basket)
        {
            _db.Basket.Add(basket);
            await _db.SaveChangesAsync();
            return basket;
        }

        public async Task<Basket> GetUserBasket(int userId)
        {
            return await _db.Basket.FirstOrDefaultAsync(b => b.UserId == userId);
        }
    }
}
