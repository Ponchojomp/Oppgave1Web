using System;
using System.Collections.Generic;
using System.Linq;
using KundeApp2.Model;
using Microsoft.AspNetCore.Mvc;

namespace KundeApp2.Controllers
{
    [Route("[controller]/[action]")]
    public class KundeController : ControllerBase
    {
        private readonly KundeDB _kundeDB;

        public KundeController(KundeDB kundeDb)
        {
            _kundeDB = kundeDb;
        }
        
        public List<Kunde> HentAlle()
        {
            List<Kunde> alleKundene = _kundeDB.Kunder.ToList();
            return alleKundene;
        }
        public List<Holdeplass> HentAlleHoldeplasser()
        {
            List<Holdeplass> alleHoldeplassene = _kundeDB.Holdeplass.ToList();
            return alleHoldeplassene;
        }
        public List<Rute> HentAlleRuter()
        {
            List<Rute> alleRutene = _kundeDB.Ruter.ToList();
            return alleRutene;
        }
    }
}
