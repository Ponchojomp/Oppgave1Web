using KundeApp2.Model;
using Microsoft.AspNetCore.Mvc;
using Oppgave1Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oppgave1Web.DAL
{
    public interface ITransportRepo 
    {

        Task<bool> LoggInn(Bruker bruker);

        Task<List<Holdeplass>> HentAlleHoldeplasser();
        Task<bool> LagreHoldeplass(Holdeplass innHoldeplass);
        Task<bool> EndreHoldeplass(Holdeplass innHoldeplass);
        Task<bool> SlettHoldeplass(int id);


        Task<List<Avgang>> HentAlleAvganger();
        Task<bool> LagreAvgang(Avganger innAvgang);
        Task<bool> EndreAvgang(Avgang innAvgang);
        Task<bool> SlettAvgang(int id);

        Task<List<Bestilling>> HentAlleBestillinger();
        Task<bool> LagreBestilling(Bestilling innBestilling);
        Task<bool> EndreBestilling(Bestilling innBestilling);
        Task<bool> SlettBestilling(int id);

        Task<List<Rute>> HentAlleRuter();
        Task<bool> LagreRute(Rute innRute);
        Task<bool> EndreRute(Rute innRute);
        Task<bool> SlettRute(int id);

        Task<Avgang> HentReise(Reise reise);

    }
}
