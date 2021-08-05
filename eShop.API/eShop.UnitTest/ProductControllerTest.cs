
using eShop.API.Controllers;
using eShop.AppService.ServiceInterfaces;
using eShop.Domain.Aggregates;
using eShop.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace eShop.UnitTest
{
    public class ProductControllerTest
    {
        private readonly Mock<IProductService> _productServiceMock;

        public ProductControllerTest()
        {
            _productServiceMock = new Mock<IProductService>();
        }

        [Fact]
        public async Task Get_all_products_success()
        {
            //Arrange
            var fakeProducts = GetFakeProducts();

            _productServiceMock.Setup(x => x.GetAllProducts())
                .Returns(Task.FromResult(fakeProducts));

            //Act
            var productController = new ProductController(_productServiceMock.Object);
            var actionResult = await productController.GetAllProducts();

            //Assert
            Assert.Equal((actionResult.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
            Assert.Equal((((ObjectResult)actionResult.Result).Value as List<Product>), fakeProducts);
        }

        private List<Product> GetFakeProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "fakeProduct1",
                    Price = 5,
                    ProductType = ProductType.Book
                },

                new Product()
                {
                    Id = 2,
                    Name = "fakeProduct2",
                    Price = 10,
                    ProductType = ProductType.Book
                },

                new Product()
                {
                    Id = 3,
                    Name = "fakeProduct3",
                    Price = 7,
                    ProductType = ProductType.DVD
                },

                new Product()
                {
                    Id = 4,
                    Name = "fakeProduct4",
                    Price = 12,
                    ProductType = ProductType.DVD
                },
            };
        }
    }
}
