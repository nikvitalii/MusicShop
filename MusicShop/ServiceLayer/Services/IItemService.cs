using MusicShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.ServiceLayer.Services
{
    public interface IItemService
    {
        public Task<IEnumerable<ItemWithProducer>> GetItemsWithProducers();
    }
}
