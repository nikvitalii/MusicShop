using MusicShop.DataLayer.Models;
using MusicShop.DataLayer.Repositories;
using MusicShop.ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.ServiceLayer.Services
{
    public interface IItemService
    {
        public Task<IEnumerable<Instrument>> GetItemsWithProducers();
        public Task<bool> AddItemToCart(AddToCartDto addToCartDto);
        public Task<IEnumerable<CartItemDto>> GetCartItems();
        public Task<bool> FinishPurchase(int customerId);
    }
}
