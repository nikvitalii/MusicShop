using MusicShop.DataLayer.Models;
using MusicShop.DataLayer.Repositories;
using MusicShop.ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.ServiceLayer.Services
{
    public class ItemService : IItemService
    {
        private IItemRepository _itemRepository { get; set; }
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<Instrument>> GetItemsAsync()
        {
            return await _itemRepository.GetAll();
        }

        public async Task<IEnumerable<Instrument>> GetItemsWithProducers()
        {
            return await _itemRepository.GetItemWithProducers();
        }

        public async Task<bool> AddItemToCart(AddToCartDto addToCartDto)
        {
            return await _itemRepository.AddItemToCart(addToCartDto);
        }

        public async Task<IEnumerable<CartItemDto>> GetCartItems()
        {
           return await _itemRepository.GetCartItems();
        }

        public async Task<bool> FinishPurchase(int customerId)
        {
            return await _itemRepository.FinishPurchase(customerId);
        }
    }
}
