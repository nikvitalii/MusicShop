using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.DataLayer.Models
{
    public class Instrument
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Producer_Id { get; set; }
        public Producer Producer { get; set; }

        public int Cost { get; set; }
        public string Country { get; set; }

        public int Instrument_Type_Id { get; set; }
        public Instrument_Type Instrument_Type { get; set; }

        public int Amount { get; set; }
    }
}
