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

        
        Task<List<Holdeplass>> HentAlleHoldeplasser();
        Task<bool> LagreHoldeplass(Holdeplass innHoldeplass);
        Task<bool> EndreHoldeplass(Holdeplass innHoldeplass);
        Task<bool> SlettHoldeplass(Holdeplass innHoldeplass);


        Task<List<Avgang>> HentAlleAvganger();
        Task<bool> LagreAvgang(Avgang innAvgang);
        Task<bool> EndreAvgang(Avgang innAvgang);
        Task<bool> SlettAvgang(Avgang innAvgang);

        Task<List<Bestilling>> HentAlleBestillinger();
        Task<bool> LagreBestilling(Bestilling innBestilling);
        Task<bool> EndreBestilling(Bestilling innBestilling);
        Task<bool> SlettBestilling(Bestilling innBestilling);

        Task<List<Rute>> HentAlleRuter();
        Task<bool> LagreRute(Rute innRute);
        Task<bool> EndreRute(Rute innRute);
        Task<bool> SlettRute(Rute innRute);

        Task<Avgang> HentReise(Reise reise);

    }
}
