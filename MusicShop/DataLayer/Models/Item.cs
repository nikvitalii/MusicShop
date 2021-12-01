using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.DataLayer.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProducerId { get; set; }
        public int Cost { get; set; }
        public int Country { get; set; }
        public int ItemTypeId { get; set; }
        public int Amount { get; set; }
    }
}
