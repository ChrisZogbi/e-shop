using eShop.Api.Domain.Exceptions;
using eShop.AppService.Models;
using eShop.AppService.ServiceInterfaces;
using eShop.Domain.Aggregates;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.AppService
{
    public class BasketService : IBasketService
    {
        private readonly IProductRepository _productRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly ILogger<BasketService> _logger;

        public BasketService(IProductRepository productRepository, IBasketRepository basketRepository, ILogger<BasketService> logger)
        {
            _productRepository = productRepository;
            _basketRepository = basketRepository;
            _logger = logger;
        }

        public async Task AddItem(AddItemModel addItemModel)
        {

            var basket = await _basketRepository.GetUserBasket(addItemModel.UserId);
            var product = new Product();

            if (basket == null)
            {
                _logger.LogInformation("[BASKET]: The user's basket doesn't exist");

                basket = await CreateBasket(addItemModel.UserId);

                _logger.LogInformation("[BASKET CREATED]: Created[<'{Date}'>], UserId : {UserId}", basket.CreationDate.ToShortDateString(), basket.UserId.ToString());
            }

            if (addItemModel.ProductId.HasValue && addItemModel.ProductId.Value > 0)
            {
                product = await _productRepository.GetById(addItemModel.ProductId.Value);
            }
            else
            {
                product = await _productRepository.GetByName(addItemModel.ProductName);
            }

            if (product == null)
            {
                throw new eShopDomainException(
                    $"Command Validation Errors for type {nameof(BasketService)}",
                    new ValidationException("Validation exception: Wrong Product"));
            }

            var basketItem = new BasketItem(basket.Id, product.Id, addItemModel.Quantity);

            await _basketRepository.AddItemToBasket(basketItem);

            _logger.LogInformation("[ITEM ADDED TO SHOPPING CART]: Added[<'{Date}'>], UserId: {UserId}, ProductId: {ProductId}, Quantity: {Quantity}, Price[<€{Price}>", 
                DateTime.UtcNow.ToShortDateString(), basket.UserId, basketItem.ProductId, basketItem.Quantity, basketItem.Product.Price);

        }

        public async Task<BasketSummaryModel> GetBasketSummary(int userId)
        {
            var basket = await _basketRepository.GetUserBasket(userId);

            var basketSummary = new BasketSummaryModel() { 
                CreationDate = basket.CreationDate.ToShortDateString(),
                BasketItems = basket.Items.Select(x => new ItemSummaryModel() { Name = x.Product.Name, Price = x.Product.Price, Quantity = x.Quantity}).ToList(),
                Total = basket.GetTotal()
            };

            return basketSummary;
        }

        private async Task<Basket> CreateBasket(int userId)
        {
            var basket = new Basket(userId);

            return await _basketRepository.CreateBasket(basket);
        }
    }
}
