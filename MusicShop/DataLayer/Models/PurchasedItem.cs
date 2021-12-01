using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.DataLayer.Models
{
    public class PurchasedItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int PurchaseId { get; set; }
        public double Discount { get; set; }
        public int Amount { get; set; }
    }
}
