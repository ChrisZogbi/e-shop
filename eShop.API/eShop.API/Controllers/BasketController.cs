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

        [HttpGet]
        [Route("summary/{userId}")]
        public async Task<ActionResult<BasketSummaryModel>> GetBasketSummary([FromRoute] int userId)
        {
            var result = await _basketService.GetBasketSummary(userId);
            return Ok(result);
        }
    }
}
