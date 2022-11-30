using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ClientApp.Model;
using diagnoseKalkulatorAngular.Repository.interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using obligDiagnoseVerktøyy.Model.entities;
namespace obligDiagnoseVerktøyy.Repository.implementation
{
    public class BrukerRepository : IBrukerRepository
    {
        private BrukerDbContext _db;
        private ILogger<BrukerRepository> _log;
        public BrukerRepository(BrukerDbContext db, ILogger<BrukerRepository> log)
        {
            _db = db;
            _log = log;
        }



      public  byte[] lagHash(string passord, byte[] salt)
        {
            return KeyDerivation.Pbkdf2(
                password: passord,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 1000,
                numBytesRequested: 32);
        }

        public byte[] lagSalt()
        {
            var csp = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csp.GetBytes(salt);
            return salt;
        }

        public async Task<bool> LoggInn(Bruker bruker)
        {
            try
            {
                Bruker funnetBruker = await _db.brukere.Where(b => string.Equals(b.brukernavn, bruker.brukernavn)).FirstAsync();

                byte[] hash = lagHash(bruker.passord, Convert.FromBase64String(funnetBruker.salt));
                bool ok = hash.SequenceEqual(Convert.FromBase64String(funnetBruker.passord));
                if (ok)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }
    }
}
