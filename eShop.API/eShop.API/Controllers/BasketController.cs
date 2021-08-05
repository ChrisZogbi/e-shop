using eShop.AppService.Models;
using eShop.AppService.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost]
        [Route("addItem")]
        public async Task<ActionResult> AddItemToBasket([FromBody] AddItemModel addItemModel)
        {
            await _basketService.AddItem(addItemModel);
            return Ok();
        }

        //[HttpGet]
        //[Route("{sku}/{transactionCurrency}")]
        //public async Task<ActionResult<TransactionModel>> GetTransactionsBySku([FromRoute] string sku, string transactionCurrency)
        //{
        //    var result = await _transactionService.GetTransactionsBySku(sku, transactionCurrency);
        //    return Ok(result);
        //}
    }
}
