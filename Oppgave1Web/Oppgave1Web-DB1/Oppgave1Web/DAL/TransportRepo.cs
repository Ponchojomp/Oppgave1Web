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

namespace Oppgave1Web.DAL
{
    public class TransportRepo : ITransportRepo
    {

        private readonly TransportDB _transportDB;
       

        public TransportRepo(TransportDB transportDB) {
            _transportDB = transportDB;
        }

        public async Task<List<Holdeplass>> HentAlleHoldeplasser()
        { 

            List<Holdeplass> alleHoldeplassene = await _transportDB.Holdeplass.ToListAsync();
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
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<Bestilling>> HentAlleBestillinger()
        {
            List<Bestilling> alleBestillingene = await _transportDB.Bestillinger.ToListAsync();
            return alleBestillingene;
        }

        public async Task<bool> LagreBestilling(Bestilling bestilling)
        {
            try
            {
                _transportDB.Bestillinger.Add(bestilling);
                await _transportDB.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Avgang> HentReise(Reise reise)
        {
            List<Avgang> avgangList = await HentAlleAvganger();
            return reise.besteAvgang(avgangList);
        }

        public async Task<bool> Slett(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LagreHoldeplass(Holdeplass innHoldeplass)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EndreHoldeplass(Holdeplass innHoldeplass)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LagreAvgang(Avgang innAvgang)
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

        public async Task<List<Rute>> HentAlleRuter()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LagreRute(Rute innRute)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EndreRute(Rute innRute)
        {
            throw new NotImplementedException();
        }
    }
}
