using System;
using System.Collections.Generic;
using System.Linq;
using Oppgave1Web.Model;
using Microsoft.AspNetCore.Mvc;

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
        public List<Rute> HentAlleRuter()
        {
            List<Rute> alleRutene = _transportDB.Ruter.ToList();
            return alleRutene;
        }
        public List<Avgang> HentAlleAvganger()
        {
            List<Avgang> alleAvgangene= _transportDB.Avganger.ToList();
            return alleAvgangene;
        }
        public List<Bestilling> HentAlleBestillinger()
        {
            List<Bestilling> alleBestillingene = _transportDB.Bestillinger.ToList();
            return alleBestillingene;
        }
    }
}
