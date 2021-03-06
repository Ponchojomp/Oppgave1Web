﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Oppgave1Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KundeApp2.Model;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

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

        public async Task<bool> SlettAvgang(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EndreHoldeplass(Holdeplass innHoldeplass)
        {
            try
            {
                var endreObjekt = await _transportDB.Holdeplass.FindAsync(innHoldeplass.ID);
                endreObjekt.navn = innHoldeplass.navn;
                await _transportDB.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
            return true;
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
                    sluttholdeplass = k.Rute.sluttholdeplass
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
                List<Rute> alleRuter = await _transportDB.Ruter.Select(k => new Rute
                {
                    ID = k.ID,
                    rutenavn = k.rutenavn,
                    varighet = k.varighet,
                    startholdeplass = k.startholdeplass,
                    sluttholdeplass = k.sluttholdeplass
                }).ToListAsync();
                return alleRuter;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return null;
            }

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

        public async Task<bool> LagreAvgang(Avganger innAvgang)
        {
            try
            {
                _transportDB.Avganger.Add(innAvgang);
                await _transportDB.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }

        public async Task<bool> LagreRute(Rute innRute)
        {
            try
            {
                _transportDB.Ruter.Add(innRute);
                await _transportDB.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }

       

        public async Task<bool> SlettHoldeplass(int id)
        {
            
                try
                {
                    Holdeplass enHoldeplass = await _transportDB.Holdeplass.FindAsync(id);
                    _transportDB.Holdeplass.Remove(enHoldeplass);
                    await _transportDB.SaveChangesAsync();
                    return true;
                }
                catch (Exception e)
                {
                    _log.LogInformation(e.Message);
                    return false;
                }
            
        }

        

        public async Task<bool> SlettBestilling(int id)
        {
            try
            {
                Bestilling enBestilling = await _transportDB.Bestillinger.FindAsync(id);
                _transportDB.Bestillinger.Remove(enBestilling);
                await _transportDB.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }

        public async Task<bool> SlettRute(int id)
        {
            try
            {
                Rute rute = await _transportDB.Ruter.FindAsync(id);
                _transportDB.Ruter.Remove(rute);
                await _transportDB.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }


        public static byte[] LagHash(string passord, byte[] salt)
        {
            return KeyDerivation.Pbkdf2(
                                password: passord,
                                salt: salt,
                                prf: KeyDerivationPrf.HMACSHA512,
                                iterationCount: 1000,
                                numBytesRequested: 32);
        }

        public static byte[] LagSalt()
        {
            var csp = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csp.GetBytes(salt);
            return salt;
        }

        public async Task<bool> LoggInn(Bruker bruker)
        {
            try
            {
                Brukere funnetBruker = await _transportDB.Brukere.FirstOrDefaultAsync(b => b.Brukernavn == bruker.Brukernavn);
                // sjekk passordet
                byte[] hash = LagHash(bruker.Passord, funnetBruker.Salt);
                bool ok = hash.SequenceEqual(funnetBruker.Passord);
                if (ok)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }
    }
}
