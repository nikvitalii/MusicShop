using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicShop.DataLayer.Models;
using MusicShop.ServiceLayer.DTOs;
using MusicShop.ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private IItemService _itemService { get; set; }

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public  IEnumerable<object> GetItems()
        {
            var res = true;
            //return Ok(res);
            return new List<object>();
        }

        [HttpGet]
        [Route("GetItemsWithProducers")]
        public async Task<IEnumerable<ItemWithProducer>> GetsItemWithProducers()
        {
            return await _itemService.GetItemsWithProducers();
        }

        [HttpPost]
        [Route("AddItemToCart")]
        public async Task<ActionResult> AddItemToCart([FromBody]AddToCartDto addToCartDto)
        {
            var res = await _itemService.AddItemToCart(addToCartDto);
            return Ok(res);
        }

        [HttpGet]
        [Route("GetCartItems")]
        public async Task<IEnumerable<CartItemDto>> GetCartItems()
        {
            return await _itemService.GetCartItems();
        }

        [HttpPost]
        [Route("FinishPurchase/{customerId}")]
        public async Task<ActionResult> FinishPurchase(int customerId)
        {
            return Ok(await _itemService.FinishPurchase(customerId));
        }
    }
}
