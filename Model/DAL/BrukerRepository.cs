using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ClientApp.Model;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClientApp.DAL
{
    public class BrukerRepository : IBrukerRepository
    {
    private BrukerContext _db;
    private ILogger<BrukerRepository> _log;
    public BrukerRepository(BrukerContext db, ILogger<BrukerRepository> log){
    _db = db;
    _log = log;
    }

    public async Task<bool> Lagre(Bruker innBruker){
    try{
        var nyBrukerRad = new Bruker();
        nyBrukerRad.Fornavn = innBruker.Fornavn;
        nyBrukerRad.Etternavn = innBruker.Etternavn;
    }
    _db.Bruker.Add(nyBrukerRad);
    await _db.SaveChangesAsync();
    return true;
    }
    catch(Exception e){
    _log.LogInformation(e.Message);
    return false;
    }
    }

    public async Task<List<Bruker>> hentAlle(){
    try{
    List<Bruker> alleBrukere = await _db.Bruker.Select(b => new Bruker{
    ID = b.ID,
    Fornavn = b.Fornavn,
    Etternavn = b.Etternavn,
    }).ToListAsync();
    return alleBrukere;
    }
    catch(Exception e){
    _log.LogInforation(e.Message);
    return null;
    }
    }

    public static byte[] LagHash(string passord, byte[] salt)
            {
                return KeyDerivation.Pbkdf2(
                    password: passord,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA512,
                    iterationCount: 1000,
                    numBytesRequested: 32);
            }

            public static byte[] LagSalt()
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
                    Brukere funnetBruker = await _db.Brukere.FirstOrDefaultAsync(b => b.Brukernavn == bruker.Brukernavn);
                    byte[] hash = LagHash(bruker.Passord, funnetBruker.Salt);
                    bool OK = hash.SequenceEqual(funnetBruker.Passord);
                    if (OK)
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
