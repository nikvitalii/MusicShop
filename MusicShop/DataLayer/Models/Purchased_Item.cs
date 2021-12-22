using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.DataLayer.Models
{
    public class Purchased_Item
    {
        public int Id { get; set; }
        public int Item_Id { get; set; }
        public Instrument Item { get; set; } 
        public int Purchase_Id { get; set; }
        public Purchase Purchase { get; set; } 
        public double Discount { get; set; }
        public int Amount { get; set; }
    }
}
