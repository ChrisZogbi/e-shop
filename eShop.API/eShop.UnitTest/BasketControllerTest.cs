using eShop.API.Controllers;
using eShop.AppService.Models;
using eShop.AppService.ServiceInterfaces;
using eShop.Domain.Aggregates;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace eShop.UnitTest
{
    public class BasketControllerTest
    {
        private readonly Mock<IBasketService> _basketServiceMock;
        private readonly Mock<IProductRepository> _productServiceMock;

        public BasketControllerTest()
        {
            _basketServiceMock = new Mock<IBasketService>();
            _productServiceMock = new Mock<IProductRepository>();
        }

        [Fact]
        public async Task Add_item_to_basket_success()
        {
            //Arrange
            var fakeUserId = 1;
            var fakeUserBasket = GetUserBasketSummaryFake();
            var fakeAddItemModela = GetAddItemModelFake();

            _basketServiceMock.Setup(x => x.AddItem(It.IsAny<AddItemModel>()));

            //Act
            var basketController = new BasketController(_basketServiceMock.Object);

            var actionResult = await basketController.AddItemToBasket(fakeAddItemModela);

            //Assert
            Assert.NotNull(actionResult);
        }

        [Fact]
        public async Task Get_customer_basket_success()
        {
            //Arrange
            var fakeUserId = 1;
            var fakeUserBasket = GetUserBasketSummaryFake();

            _basketServiceMock.Setup(x => x.GetBasketSummary(It.IsAny<int>()))
                .Returns(Task.FromResult(fakeUserBasket));

            //Act
            var basketController = new BasketController(_basketServiceMock.Object);

            var actionResult = await basketController.GetBasketSummary(fakeUserId);

            //Assert
            Assert.Equal((actionResult.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as BasketSummaryModel), fakeUserBasket);
        }

        private BasketSummaryModel GetUserBasketSummaryFake()
        {
            return new BasketSummaryModel()
            {
                CreationDate = DateTime.UtcNow.ToShortDateString(),
                BasketItems = new List<ItemSummaryModel>()
                {
                    new ItemSummaryModel{ Name = "TestItem", Price = 5, Quantity = 2}
                }
            };
        }

        private AddItemModel GetAddItemModelFake()
        {
            return new AddItemModel()
            {
                UserId = 1,
                ProductId = 1,
                Quantity = 2,
                ProductName = "TestProduct"
            };
        }
    }
}
