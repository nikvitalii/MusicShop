using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.DataLayer.Models
{
    public class ItemWithProducer
    {
        public int ItemId { get; set; }
        public string Item { get; set; }

        public int ProducerId { get; set; }
        public string Producer { get; set; }

        public int TypeId { get; set; }
        public string Type { get; set; }

        public int Cost { get; set; }
        public int Amount { get; set; }
    }
}
