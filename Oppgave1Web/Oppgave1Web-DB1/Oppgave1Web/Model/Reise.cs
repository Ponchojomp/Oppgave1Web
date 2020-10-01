using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oppgave1Web.Model
{
    public class Reise
    {
        public int avgangHoldeplass { get; set; }
        public int anokmstHoldeplass { get; set; }
        public int tid { get; set; }


        public Reise getReise()
        {
            return this;
        }
    }
}
