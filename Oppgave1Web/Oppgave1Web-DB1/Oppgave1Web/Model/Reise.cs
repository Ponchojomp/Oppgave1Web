using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oppgave1Web.Model
{
    public class Reise
    {
        public int start { get; set; }
        public int slutt { get; set; }
        public int tid { get; set; }
        public List<Avgang> muligeAvganger = new List<Avgang>();


        public Avgang besteAvgang(List<Avgang> avganger)
        {
            for (int i = 0; i < avganger.Count; i++)
            {
                if (avganger[i].startholdeplass.Equals(this.start) && avganger[i].sluttholdeplass.Equals(this.slutt) && avganger[i].tid >= this.tid)
                {
                    muligeAvganger.Add(avganger[i]);
                }
            }
            if (muligeAvganger.Count > 1)
            {
                bool sorted = false;

                while (sorted == false)
                {
                    sorted = true;
                    for (int i = 1; i < muligeAvganger.Count; i++)
                    {
                        Avgang a = muligeAvganger[i - 1];
                        Avgang b = muligeAvganger[i];
                        if (b.tid < a.tid)
                        {
                            sorted = false;
                            muligeAvganger[i - 1] = b;
                            muligeAvganger[i] = a;
                        }
                    }
                }
                return muligeAvganger[0];

            } else if (muligeAvganger.Count == 1){
                return muligeAvganger[0];
            } else {
                return null;
            }
        }
    }
}
