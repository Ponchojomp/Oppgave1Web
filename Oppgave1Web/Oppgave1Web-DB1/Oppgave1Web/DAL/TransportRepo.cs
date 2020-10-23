using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Oppgave1Web.Model;
using Oppgave1Web.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Oppgave1Web.DAL
{
    public class TransportRepo : ITransportRepo
    {

        private readonly TransportDB _transportDB;

        private ILogger<TransportRepo> _log;
       

        public TransportRepo(TransportDB transportDB, ILogger<TransportRepo> log) {
            _transportDB = transportDB;
            _log = log;
        }

        public async Task<List<Holdeplass>> HentAlleHoldeplasser()
        {

            try
            {
                List<Holdeplass> alleHoldeplassene = await _transportDB.Holdeplass.ToListAsync();
                return alleHoldeplassene;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return null;
            }
            
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
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return null;
            }
        }

        public async Task<List<Bestilling>> HentAlleBestillinger()
        {
            try
            {
                List<Bestilling> alleBestillingene = await _transportDB.Bestillinger.ToListAsync();
                return alleBestillingene;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return null;
            }            
        }

        public async Task<List<Rute>> HentAlleRuter()
        {

            try
            {
                List<Rute> ruteList = await _transportDB.Rute.ToListAsync();
                return ruteList;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return null;
            }
            throw new NotImplementedException();

        }

        public async Task<Avgang> HentReise(Reise reise)
        {
            try
            {
                List<Avgang> avgangList = await HentAlleAvganger();
                return reise.besteAvgang(avgangList);
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return null;
            }
        }

        public async Task<bool> LagreBestilling(Bestilling bestilling)
        {
            try
            {
                _transportDB.Bestillinger.Add(bestilling);
                await _transportDB.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }

        public async Task<bool> LagreHoldeplass(Holdeplass innHoldeplass)
        {
            try
            {
                _transportDB.Holdeplass.Add(innHoldeplass);
                await _transportDB.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }

        public async Task<bool> LagreAvgang(Avgang innAvgang)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LagreRute(Rute innRute)
        {
            try
            {
                _transportDB.Rute.Add(innRute);
                await _transportDB.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }

        public async Task<bool> EndreHoldeplass(Holdeplass innHoldeplass)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EndreAvgang(Avgang innAvgang)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EndreBestilling(Bestilling innBestilling)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EndreRute(Rute innRute)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SlettHoldeplass(Holdeplass innHoldeplass)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SlettAvgang(Avgang innAvgang)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SlettBestilling(Bestilling innBestilling)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SlettRute(Rute innRute)
        {
            throw new NotImplementedException();
        }
    }
}
