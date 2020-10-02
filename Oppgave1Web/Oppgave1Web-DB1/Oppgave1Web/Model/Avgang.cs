using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oppgave1Web.Model
{
    public class Avgang
    { 
        public string ID { get; set; }
        public string tid  { get; set; }
        public int ruteId { get; set; }
        public string rutenavn { get; set; }
        public int varighet { get; set; }
        public int startholdeplass { get; set; }
        public int sluttholdeplass { get; set; }
    }
}
