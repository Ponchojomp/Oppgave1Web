using Microsoft.AspNetCore.Server.Kestrel.Core;
using Oppgave1Web.Controllers;
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
        public Holdeplass start { get; set; }
        public Holdeplass slutt { get; set; }

        public Rute()
        {
            
            TransportController tc = new TransportController();
            List<Holdeplass> holdeplassList = tc.HentAlleHoldeplasser();

            for(int i = 0; i<holdeplassList.Count; i++)
            {
                if(holdeplassList[i].ID == startholdeplass)
                {
                    start = holdeplassList[i];
                }

                if (holdeplassList[i].ID == sluttholdeplass)
                {
                    slutt = holdeplassList[i];
                }


            }
        }
    }
}
