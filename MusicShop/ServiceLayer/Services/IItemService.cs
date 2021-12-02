using MusicShop.DataLayer.Models;
using MusicShop.ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.ServiceLayer.Services
{
    public interface IItemService
    {
        public Task<IEnumerable<ItemWithProducer>> GetItemsWithProducers();
        public Task<bool> AddItemToCart(AddToCartDto addToCartDto);
        public Task<IEnumerable<CartItemDto>> GetCartItems();
        public Task<bool> FinishPurchase(int customerId);
    }
}
