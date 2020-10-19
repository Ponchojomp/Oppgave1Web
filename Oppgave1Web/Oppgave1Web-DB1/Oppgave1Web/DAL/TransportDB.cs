using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oppgave1Web.Model
{
    
    public class Avganger
    {
        public string ID { get; set; }
        public int tid { get; set; }

        virtual public Ruter Rute { get; set; }
    }

    public class Ruter
    {
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string rutenavn { get; set; }
        public int varighet { get; set; }
        public int startholdeplass { get; set; }
        public int sluttholdeplass { get; set; }
    }
    public class Kunder
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        virtual public Poststeder Poststed { get; set; }
    }

    public class Poststeder
    {
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Postnr { get; set; }
        public String Poststed { get; set; }

        // denne listen ikke nødvendig med mindre man skal finne kundene på et gitt postnr (altså gå inn via Poststeder-collection)
        virtual public List<Kunder> Kunder { get; set; }
    }
    public class TransportDB :DbContext
    {
        public TransportDB (DbContextOptions<TransportDB> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Holdeplass> Holdeplass { get; set; }
        public DbSet<Avganger> Avganger { get; set; }
        public DbSet<Bestilling> Bestillinger { get; set; }
        public DbSet<Kunder> Kunder { get; set; }
        public DbSet<Poststeder> Poststeder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
