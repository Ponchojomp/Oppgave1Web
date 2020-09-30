using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oppgave1Web.Model
{
    public class TransportDB :DbContext
    {
        public TransportDB (DbContextOptions<TransportDB> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Rute> Ruter { get; set; }
        public DbSet<Holdeplass> Holdeplass { get; set; }
        public DbSet<Avgang> Avganger { get; set; }
        public DbSet<Bestilling> Bestillinger { get; set; }

    }
}
