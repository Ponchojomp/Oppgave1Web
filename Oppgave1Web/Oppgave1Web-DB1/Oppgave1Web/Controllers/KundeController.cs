using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Logging;
using KundeApp2.DAL;
using KundeApp2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KundeApp2.Controllers
{
    [Route("[controller]/[action]")]
    public class KundeController : ControllerBase
    {
        private readonly IKundeRepo _db;
        private ILogger<KundeController> _log;

        public KundeController(IKundeRepo db, ILogger<KundeController> log)
        {
            _db = db;
            _log = log;
        }

        public async Task<bool> Lagre(Kunde innKunde)
        {
            return await _db.Lagre(innKunde);
        }

        public async Task<List<Kunde>> HentAlle()
        {
            _log.LogInformation("Halla");
            return await _db.HentAlle();
        }

        public async Task<bool> Slett(int id)
        {
            return await _db.Slett(id);
        }

        public async Task<Kunde> HentEn(int id)
        {
            return await _db.HentEn(id);
        }

        public async Task<bool> Endre(Kunde endreKunde)
        {
            return await _db.Endre(endreKunde);
        }
    }
}
