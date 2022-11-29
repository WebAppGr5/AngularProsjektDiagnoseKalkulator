using System.Collections.Generic;
using System.Threading.Tasks;
using diagnoseKalkulatorAngular.Repository.interfaces;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using obligDiagnoseVerktøyy.Model.DTO;
using obligDiagnoseVerktøyy.Model.entities;

using obligDiagnoseVerktøyy.Repository.interfaces;


namespace obligDiagnoseVerktøyy.Controllers.implementations
{
    [Route("[controller]/[action]")]

    public class LoginController : ControllerBase
    {
        private IBrukerRepository _db;

        private ILogger<LoginController> _log;

        private const string _LoggetInn = "InnLogget";
        private const string _ikkeLoggetInn = "";

        public LoginController(IBrukerRepository db, ILogger<LoginController> log)
        {
            _db = db;
            _log = log;
        }
    

        public async Task<ActionResult> erInnlogget()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_LoggetInn)))
            {
                return Ok("false");
            }
            return Ok("true");
            
        }     
       [HttpPost]
        public async Task<ActionResult> loggInn([FromBody] BrukerLogin brukerLogin)
        {
            if (ModelState.IsValid)
            {
                Bruker bruker = new Bruker { brukernavn = brukerLogin.brukernavn, passord = brukerLogin.passord };
                bool returnOK = await _db.LoggInn(bruker);

                if (!returnOK)
                {
                    _log.LogInformation("Innloggingen feilet for bruker");
                    HttpContext.Session.SetString(_LoggetInn, _ikkeLoggetInn);
                    return Ok(false);
                }
                HttpContext.Session.SetString(_LoggetInn, _LoggetInn);
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

