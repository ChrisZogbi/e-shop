using eShop.AppService;
using eShop.Domain.Aggregates;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace eShop.UnitTest.Services
{
    public class BasketServiceTest
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IBasketRepository> _basketRepositoryMock;
        private readonly Mock<ILogger<BasketService>> _loggerMock;

        public BasketServiceTest()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _basketRepositoryMock = new Mock<IBasketRepository>();
            _loggerMock = new Mock<ILogger<BasketService>>();
        }

        #region Chris

        [Fact]
        public async Task Add_item_by_id_to_existing_basket_success()
        {
            //Arrange
            var userBasketFake = GetUserBasketFake();

            _basketRepositoryMock.Setup(x => x.GetUserBasket(It.IsAny<int>()))
                .Returns(Task.FromResult(userBasketFake));
            //Act


            //Assert

        }

        [Fact]
        public async Task Add_item_by_id_to_not_existing_basket_success()
        {
            //Arrange


            //Act


            //Assert

        }

        #endregion

        #region Carlos

        [Fact]
        public async Task Add_item_by_name_to_existing_basket_success()
        {
            //Arrange
            var userBasketFake = GetUserBasketFake();

            _basketRepositoryMock.Setup(x => x.GetUserBasket(It.IsAny<int>()))
                .Returns(Task.FromResult(userBasketFake));
            
            //Act


            //Assert

        }

        [Fact]
        public async Task Add_item_by_name_to_not_existing_basket_success()
        {
            //Arrange


            //Act


            //Assert

        }

        #endregion

        [Fact]
        public async Task Add_item_with_not_existing_product()
        {
            //Arrange


            //Act


            //Assert

        }

        private Basket GetUserBasketFake()
        {
            return new Basket()
            {
                Id = 1,
                UserId = 2,
                CreationDate = DateTime.UtcNow,
                Items = new List<BasketItem>()
            };
        }
    }
}
