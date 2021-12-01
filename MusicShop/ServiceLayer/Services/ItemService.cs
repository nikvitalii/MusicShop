using MusicShop.DataLayer.Models;
using MusicShop.DataLayer.Repositories;
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

        public IEnumerable<Item> GetItems()
        {
            return  _itemRepository.GetItems();
        }

        public async Task<IEnumerable<ItemWithProducer>> GetItemsWithProducers()
        {
            return await _itemRepository.GetItemWithProducers();
        }
    }
}
