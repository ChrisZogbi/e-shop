using eShop.AppService.ServiceInterfaces;
using eShop.Domain.Aggregates;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var result = await _productService.GetAllProducts();
            return Ok(result);
        }
    }
}
