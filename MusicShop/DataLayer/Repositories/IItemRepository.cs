using MusicShop.DataLayer.Models;
using MusicShop.ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.DataLayer.Repositories
{
    public interface IItemRepository : IRepository<Instrument>
    {
        public Task<IEnumerable<Instrument>> GetItemWithProducers();
        public Task<bool> AddItemToCart(AddToCartDto addToCartDto);
        public Task<IEnumerable<CartItemDto>> GetCartItems();
        public Task<bool> FinishPurchase(int customerId);
    }
}
