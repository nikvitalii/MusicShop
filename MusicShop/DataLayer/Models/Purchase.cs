using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.DataLayer.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public bool Finished { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
