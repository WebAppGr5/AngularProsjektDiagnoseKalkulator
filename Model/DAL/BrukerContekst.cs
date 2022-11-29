using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClientApp.Model
{
    public class Brukerpersonalia{
    public int ID {get; set;}
    public string Fornavn {get; set;}
    public string Etternavn {get; set;}
    }

    public class BrukerLogIn{
        public int ID {get; set;}
        public string Brukernavn {get; set;}
        public string Passord {get; set;}
        public string Salt {get; set;}
    }

    public class BrukerContext : DbContext {
        public BrukerContext (DbContextOption<BrukerContext> options) : base(options)
        {
        Database.EnsureCreated();
        }
        public DbSet<Brukerpersonalia> Brukerppersonalia {get;set;}
        public DbSet<BrukerLogIn> BrukerLogIn {get;set;}

        protected override void OnConfiguring(DbContextOptionBuilder optionsBuilder){
        optionsBuilder.UseLazyLoadingProxies();
        }

    }
}