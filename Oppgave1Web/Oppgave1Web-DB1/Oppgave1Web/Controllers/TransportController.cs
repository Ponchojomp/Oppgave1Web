using System;
using System.Collections.Generic;
using System.Linq;
using Oppgave1Web.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Oppgave1Web.DAL;
using Microsoft.AspNetCore.Http;
using KundeApp2.Model;

namespace Oppgave1Web.Controllers
{
    [Route("[controller]/[action]")]
    public class TransportController : ControllerBase
    {
       
        private readonly ITransportRepo _transportDB;
        private readonly ILogger<TransportController> _log;
        private const string _loggetInn = "LoggetInn";

        public TransportController(ITransportRepo transportDB, ILogger<TransportController> log)
        {
            _transportDB = transportDB;
            _log = log;
        }


        public async Task<ActionResult> nyHoldeplass(Holdeplass holdeplass)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }
            if (ModelState.IsValid)
            {
                bool returOK = await _transportDB.LagreHoldeplass(holdeplass);
                if (!returOK)
                {
                    _log.LogInformation("Holdeplassen kunne ikke lagres!");
                    return BadRequest("Holdeplassen kunne ikke lagres");
                }
                return Ok("Holdeplass lagret");
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }
        public async Task<ActionResult> GetHoldeplass(Holdeplass holdeplass)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }
            if (ModelState.IsValid)
            {
                bool returOK = await _transportDB.EndreHoldeplass(holdeplass);
                if (!returOK)
                {
                    _log.LogInformation("Endringen kunne ikke utføres");
                    return NotFound("Endringen kunne ikke utføres");
                }
                return Ok("endret");
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }


        public async Task<ActionResult<Holdeplass>> HentAlleHoldeplasser()
        {

            //Eksempel på log
            _log.LogInformation("Halla");

           

            List<Holdeplass> alleHoldeplassene = await _transportDB.HentAlleHoldeplasser();
            return Ok(alleHoldeplassene);
        }

        public async Task<ActionResult<Avgang>> HentAlleAvganger()
        {
            List<Avgang> alleAvgangene = await _transportDB.HentAlleAvganger();
            return Ok(alleAvgangene);
        }

        public async Task<ActionResult<Rute>> HentAlleRuter()
        {
            List<Rute> alleRutene = await _transportDB.HentAlleRuter();
            return Ok(alleRutene);
        }

        public async  Task<ActionResult<Bestilling>> HentAlleBestillinger()
        {
            List<Bestilling> alleBestillingene = await _transportDB.HentAlleBestillinger();
            return Ok(alleBestillingene);
        }

        public async Task<ActionResult> LagreBestilling(Bestilling bestilling)
        {
            bool returOK = await _transportDB.LagreBestilling(bestilling);
            if (!returOK)
            {
                _log.LogInformation("Bestilling ble ikke lagret");
                return BadRequest("Bestilling ble ikke lagret");
            }
            return Ok("Bestilling lagret");
        }

        public async Task<Avgang> HentReise(Reise reise)
        {
            List<Avgang> avgangList = await _transportDB.HentAlleAvganger();
            return reise.besteAvgang(avgangList);
        }

        public async Task<ActionResult> SlettHoldeplass(int id)
        {
            bool returOK = await _transportDB.SlettHoldeplass(id);
            if (!returOK)
            {
                _log.LogInformation("Kunne ikke slette holdeplass");
                return NotFound("Kunne ikke slette holdeplass");
            }
            return Ok("Holdeplass slettet");
        }

        public async Task<ActionResult> SlettBestilling(int id)
        {
            bool returOK = await _transportDB.SlettBestilling(id);
            if (!returOK)
            {
                _log.LogInformation("Kunne ikke slette bestilling");
                return NotFound("Kunne ikke slette bestilling");
            }
            return Ok("Bestilling slettet");
        }

        public async Task<ActionResult> SlettRute(int id)
        {
            bool returOK = await _transportDB.SlettRute(id);
            if (!returOK)
            {
                _log.LogInformation("Kunne ikke slette rute");
                return NotFound("Kunne ikke slette rute");
            }
            return Ok("Rute slettet");
        }

        public async Task<ActionResult> LoggInn(Bruker bruker)
        {
            if (ModelState.IsValid)
            {
                bool returnOK = await _transportDB.LoggInn(bruker);
                if (!returnOK)
                {
                    _log.LogInformation("Innloggingen feilet for bruker" + bruker.Brukernavn);
                    HttpContext.Session.SetString(_loggetInn, "");
                    return Ok(false);
                }
                HttpContext.Session.SetString(_loggetInn, "LoggetInn");
                return Ok(true);
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }

        public void LoggUt()
        {
            HttpContext.Session.SetString(_loggetInn, "");
        }
    }
}
