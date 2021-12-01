using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.DataLayer.Models
{
    public class TopCustomer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int TotalSum { get; set; }
    }
}
