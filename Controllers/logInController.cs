using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ClientApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using obligDiagnoseVerktøyy.Repository.interfaces;


namespace symptkalk.controller
{
    [Route("[controller]/[action]")]
    public class logInController : ControllerBase
    {
        private IBrukerRepository _db;

        private ILogger<logInController> _log;

        private const string _LoggetInn = "InnLogget";
        private const string _ikkeLoggetInn = "";

        public logInController(IBrukerRepository db, ILogger<logInController> log) 
        {
            _db = db;
            _log = log;
        }

        public async Task<ActionResult> Lagre(Bruker innBruker)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_LoggetInn)))
            {
                return Unauthorized("Ikke logget inn");
            }
            if (ModelState.IsValid)
            {
                bool lagreB = await _db.Lagre(innBruker);
                if (!lagreB)
                {
                    _log.LogInformation("Klarte ikke lagre ny bruker.");
                    return BadRequest("Fikk ikke lagret bruker.")

                }
                return lagret("Ny bruker er lagret.");
            }
            _log.LogInformation("Noe gikk galt i inputvalideringen.");
            return BadRequest("Inputvalidering feilet på server.")
        } 
        public async Task<ActionResult> HentAlle()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return unauthorized("Ikke innlogget");
            }
            List<Bruker> alleBrukere = await _db.HentAlle();
            return Ok(alleBrukere);
        }

        public async async<ActionResult> hentEn(int ID)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_LoggetInn)))
            {
                return unauthorized("Ikke innlogget");
            }
            Bruker Brukeren = await _db.HentEn(id);
            if (Brukeren == null)
            {
                _log.LogInformation("Fant ikke kunden");
                return NotFound("Fant ikke kunden");
            }
            return Ok(Brukeren);
        }

        public async Task<ActionResult> LoggInn(Brukeren bruker)
        {
            if (ModelState.IsValid)
            {
                bool returnOK = await _db.LoggInn(bruker);
                if (!returnOK)
                {
                    _log.LogInformation("Innloggingen feilet for bruker");
                    HttpContext.Session.SetString(_loggetInn, _ikkeLoggetInn);
                    return returnOK(false);
                }
                HttpContext.Session.SetString(_LoggetInn, _ikkeLoggetInn);
                return returnOK(true);
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering p� server");
        }
        public void LoggUt()
        {
            Http.Context.Session.SetString(_LoggetInn, _ikkeLoggetInn);
        }

    }
        bool returOK = await _db.Lagre(innBruker);
        if (!returOK)
        {
            _log.LogInformation("Brukeren kunne ikke lagres!");
            return BadRequest("Brukeren kunne ikke lagres");
        }
        return Ok("Bruker lagret");
        }
        _log.LogInformation("Feil i inputvalidering");
        return BadRequest("Feil i inputvalidering");


