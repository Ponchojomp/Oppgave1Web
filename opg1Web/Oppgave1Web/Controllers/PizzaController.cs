using System.Collections.Generic;
using System.Linq;
using Oppgave1Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Oppgave1Web.Controllers
{
    [Route("[controller]/[action]")]
    public class PizzaController:ControllerBase
    {
        private readonly PizzaContext _db;

        public PizzaController(PizzaContext db)
        {
            _db = db;
        }

        [HttpPost]
        public void SettInn(Pizza bestiltPizza)
        {
            // returnerer ikke noe, ingen feilhåndtering mot databasen her

            var bestilling = new Bestilling()
            {
                Antall = bestiltPizza.Antall,
                PizzaType = bestiltPizza.PizzaType,
                Tykkelse = bestiltPizza.Tykkelse
            };

            Kunde funnetKunde = _db.Kunder.FirstOrDefault(k => k.Navn == bestiltPizza.Navn);

            if (funnetKunde == null)
            {
                // opprett kunden
                var kunde = new Kunde
                {
                    Navn = bestiltPizza.Navn,
                    Adresse = bestiltPizza.Adresse,
                    Telefonnr = bestiltPizza.Telefonnr,
                };
                // legg bestillingen inn i kunden
                kunde.Bestillinger = new List<Bestilling>();
                kunde.Bestillinger.Add(bestilling);
                _db.Kunder.Add(kunde);
                _db.SaveChanges();
            }
            else
            {
                funnetKunde.Bestillinger.Add(bestilling);
                _db.SaveChanges();
            }
        }

        public List<Pizza> HentAlle()
        {
            List<Kunde> alleKunder = _db.Kunder.ToList();
            List<Pizza> alleBestillinger = new List<Pizza>();
            foreach (var kunde in alleKunder)
            {
                foreach (var best in kunde.Bestillinger)
                {
                    var enBestilling = new Pizza
                    {
                        Navn = kunde.Navn,
                        Adresse = kunde.Adresse,
                        Telefonnr = kunde.Telefonnr,
                        PizzaType = best.PizzaType,
                        Antall = best.Antall,
                        Tykkelse = best.Tykkelse
                    };
                    alleBestillinger.Add(enBestilling);
                }
            }
            return alleBestillinger;
        }
    }
}
