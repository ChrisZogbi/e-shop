using eShop.AppService.ServiceInterfaces;
using eShop.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.AppService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAll();
        }
    }
}
