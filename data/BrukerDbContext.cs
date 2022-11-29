using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using obligDiagnoseVerktøyy.Model.entities;

namespace ClientApp.Model
{

    public class BrukerDbContext : DbContext
    {

        public BrukerDbContext(DbContextOptions<BrukerDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Brukerpersonalia> Brukerpersonalia { get; set; }
        public DbSet<Bruker> brukere { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brukerpersonalia>().ToTable("brukerpersonalia").HasKey(k => k.ID);

            modelBuilder.Entity<Bruker>().ToTable("bruker").HasKey(k => k.ID);
        }
    }
}