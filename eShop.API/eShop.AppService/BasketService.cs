using eShop.AppService.Models;
using eShop.AppService.ServiceInterfaces;
using eShop.Domain.Aggregates;
using System.Threading.Tasks;

namespace eShop.AppService
{
    public class BasketService : IBasketService
    {
        private readonly IProductRepository _productRepository;
        private readonly IBasketRepository _basketRepository;

        public BasketService(IProductRepository productRepository, IBasketRepository basketRepository)
        {
            _productRepository = productRepository;
            _basketRepository = basketRepository;
        }

        public async Task AddItem(AddItemModel addItemModel)
        {
            var basket = await _basketRepository.GetUserBasket(addItemModel.UserId);
            var product = new Product();

            if (basket == null)
                basket = await CreateBasket(addItemModel.UserId);

            if (addItemModel.ProductId.HasValue)
            {
                product = await _productRepository.GetById(addItemModel.ProductId.Value);
            }
            else
            {
                product = await _productRepository.GetByName(addItemModel.ProductName);
            }

            var basketItem = new BasketItem(basket.Id, product.Id, addItemModel.Quantity);

            await _basketRepository.AddItemToBasket(basketItem);
        }

        public Task<BasketSummaryModel> GetBasketSummary()
        {
            throw new System.NotImplementedException();
        }

        private async Task<Basket> CreateBasket(int userId)
        {
            var basket = new Basket(userId);

            return await _basketRepository.CreateBasket(basket);
        }
    }
}
