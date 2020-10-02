using System;
using System.Collections.Generic;
using System.Linq;
using Oppgave1Web.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Oppgave1Web.Controllers
{
    [Route("[controller]/[action]")]
    public class TransportController : ControllerBase
    {
        private readonly TransportDB _transportDB;

        public TransportController(TransportDB transportDB)
        {
            _transportDB = transportDB;
        }
        
        public List<Holdeplass> HentAlleHoldeplasser()
        {
            List<Holdeplass> alleHoldeplassene = _transportDB.Holdeplass.ToList();
            return alleHoldeplassene;
        }

        public async Task<List<Avgang>> HentAlleAvganger()
        {
            try
            {
                List<Avgang> alleAvgangene = await _transportDB.Avganger.Select(k => new Avgang

                {
                    ID = k.ID,
                    tid = k.tid,
                    ruteId = k.Rute.ID,
                    rutenavn = k.Rute.rutenavn,
                    varighet = k.Rute.varighet,
                    startholdeplass = k.Rute.startholdeplass,
                    sluttholdeplass = k.Rute.sluttholdeplass,
                }).ToListAsync();

                return alleAvgangene;
            }
            catch(Exception e)
            {
                Trace.WriteLine(e.Message);
                return null; 
            }
        }
        public List<Bestilling> HentAlleBestillinger()
        {
            List<Bestilling> alleBestillingene = _transportDB.Bestillinger.ToList();
            return alleBestillingene;
        }
    }
}
