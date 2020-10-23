using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Oppgave1Web.Model;

namespace Oppgave1Web.DAL
{
    public static class DBInit
    {
        public static void Initialize(IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();

            var db = serviceScope.ServiceProvider.GetService<TransportDB>();

            db.Database.EnsureCreated();


            // lag en påoggingsbruker
            var bruker = new Brukere();
            bruker.Brukernavn = "Admin";
            string passord = "Test11";
            byte[] salt = TransportRepo.LagSalt();
            byte[] hash = TransportRepo.LagHash(passord, salt);
            bruker.Passord = hash;
            bruker.Salt = salt;
            db.Brukere.Add(bruker);

            db.SaveChanges();
        }
    }

}
