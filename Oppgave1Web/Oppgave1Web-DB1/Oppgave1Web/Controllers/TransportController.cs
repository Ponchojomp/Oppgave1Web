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

namespace Oppgave1Web.Controllers
{
    [Route("[controller]/[action]")]
    public class TransportController : ControllerBase
    {
       
        private readonly ITransportRepo _transportDB;
        private readonly ILogger<TransportController> _log;

        public TransportController(ITransportRepo transportDB, ILogger<TransportController> log)
        {
            _transportDB = transportDB;
            _log = log;
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
    }
}
