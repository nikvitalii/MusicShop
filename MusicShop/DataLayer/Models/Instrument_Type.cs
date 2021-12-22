using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.DataLayer.Models
{
    public class Instrument_Type
    {
        public Instrument_Type()
        {
            Instruments = new List<Instrument>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Instrument> Instruments { get; set; }   
    }
}
