using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicShop.DataLayer.Models;
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
    }
}
