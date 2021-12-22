using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.DataLayer.Models
{
    public class Purchase
    {
        public Purchase()
        {
            PurchasedItems = new List<Purchased_Item>();
        }
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        public Customer Customer { get; set; } 
        public bool Finished { get; set; }
        public DateTime Purchase_Date { get; set; }
        public IEnumerable<Purchased_Item> PurchasedItems { get; set; }
    }
}
