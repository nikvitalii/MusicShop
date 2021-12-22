using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.DataLayer.Models
{
    public class Customer
    {
        public Customer()
        {
            PurchaseList = new List<Purchase>();
        }

        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Second_Name { get; set; }
        public string Phone_Number { get; set; }
        public string E_Mail { get; set; }
        public DateTime Registration_Date { get; set; }
        public IEnumerable<Purchase> PurchaseList { get; set;}
    }
}
