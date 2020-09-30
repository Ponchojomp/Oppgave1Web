using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KundeApp2.Model
{
    public class KundeDB :DbContext
    {
        public KundeDB (DbContextOptions<KundeDB> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Kunde> Kunder { get; set; }
        public DbSet<Rute> Ruter { get; set; }
        public DbSet<Holdeplass> Holdeplass { get; set; }
        
    }
}
