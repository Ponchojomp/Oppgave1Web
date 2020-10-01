using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oppgave1Web.Model
{
    public class Rute
    {
        public int ID { get; set; }
        public string rutenavn { get; set; }
        public int varighet { get; set; }
        public int startholdeplass{ get; set; }
        public int sluttholdeplass { get; set; }
    }
}
