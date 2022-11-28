using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using obligDiagnoseVerktøyy.Model.DTO;
using obligDiagnoseVerktøyy.Model.entities;

using obligDiagnoseVerktøyy.Repository.interfaces;


namespace obligDiagnoseVerktøyy.Controllers.implementations
{
    [Route("[controller]/[action]")]

    public class LogInController : ControllerBase
    {
        private IBrukerRepository _db;

        private ILogger<LogInController> _log;

        private const string _LoggetInn = "InnLogget";
        private const string _ikkeLoggetInn = "";

        public LogInController(IBrukerRepository db, ILogger<LogInController> log)
        {
            _db = db;
            _log = log;
        }

        public async Task<ActionResult> Lagre([FromBody] BrukerLogin innBruker)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_LoggetInn)))
            {
                return Unauthorized("Ikke logget inn");
            }
            if (ModelState.IsValid)
            {
                //bool lagreB = await _db.Lagre(innBruker);
                bool lagreB = true;
                if (!lagreB)
                {
                    _log.LogInformation("Klarte ikke lagre ny bruker.");
                    return BadRequest("Fikk ikke lagret bruker.");

                };
                return Ok("Ny bruker er lagret.");
            }
            _log.LogInformation("Noe gikk galt i inputvalideringen.");
            return BadRequest("Inputvalidering feilet på server.");
        }
        [HttpGet]
        public async Task<ActionResult> HentAlle()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_LoggetInn)))
            {
                return Unauthorized("Ikke innlogget");
            }
            //List<BrukerInfo> alleBrukere = await _db.HentAlle();
            //   return Ok(alleBrukere);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> hentEn(int ID)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_LoggetInn)))
            {
                return Unauthorized("Ikke innlogget");
            }
            //BrukerInfo Brukeren = await _db.HentEn(id);
            BrukerInfo brukeren = null;
            if (brukeren == null)
            {
                _log.LogInformation("Fant ikke kunden");
                return NotFound("Fant ikke kunden");
            }
            return Ok(brukeren);
        }

        [HttpPost]
        public async Task<ActionResult> loggInn([FromBody] BrukerLogin brukerLogin)
        {
            if (ModelState.IsValid)
            {
                //     bool returnOK = await _db.LoggInn(bruker);
                bool returnOK = true;
                if (!returnOK)
                {
                    _log.LogInformation("Innloggingen feilet for bruker");
                    HttpContext.Session.SetString(_LoggetInn, _ikkeLoggetInn);
                    return Ok(false);
                }
                HttpContext.Session.SetString(_LoggetInn, _ikkeLoggetInn);
                return Ok(true);
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering p� server");
        }
        [HttpGet]
        public void loggUt()
        {
            HttpContext.Session.SetString(_LoggetInn, _ikkeLoggetInn);
        }

    }
}

