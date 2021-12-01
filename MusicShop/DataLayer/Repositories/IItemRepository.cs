using MusicShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.DataLayer.Repositories
{
    public interface IItemRepository
    {
        public Task<IEnumerable<ItemWithProducer>> GetItemWithProducers();
        public IEnumerable<Item> GetItems();
    }
}
