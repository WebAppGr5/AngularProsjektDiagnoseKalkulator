using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ClientApp.DAL;

namespace ClientApp.Model
{
    public static class DBInit
    {
        public static void Initialize(IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();

            var db = serviceScope.ServiceProvider.GetService<BrukerContext>();

            db.Database.EnsureCreated();

            var Bruker1 = new Bruker { Fornavn = "Mike", Etternavn = "Clawthorn"};
            var bruker2 = new Bruker { Fornavn = "Nina", Etternavn = "George"};

            db.Bruker.Add(Bruker1);
            db.Bruker.Add(Bruker2);

            // lag en påoggingsbruker
            var bruker = new Brukere();
            bruker.Brukernavn = "Admin";
            var passord = "Test11";
            byte[] salt = BrukerRepository.LagSalt();
            byte[] hash = BrukerRepository.LagHash(passord, salt);
            bruker.Passord = hash;
            bruker.Salt = salt;
            db.Brukere.Add(bruker);

            db.SaveChanges();
        }
    }

}