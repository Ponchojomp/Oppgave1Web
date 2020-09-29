using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KundeApp2.Model
{
    public class Rute
    {
        public int ID { get; set; }
        public string Rutenavn { get; set; }
        public int Rutetid { get; set; }
        public string Startholdeplass{ get; set; }
        public string Sluttholdeplass { get; set; }
    }
}
