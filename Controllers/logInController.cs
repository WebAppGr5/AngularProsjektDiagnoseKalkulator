using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using obligDiagnoseVerkt�yy.Repository.interfaces;
using symptkalk.Model;

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
    
        public async Task<ActionResult> Lagre (Bruker innBruker)
    }
    if (ModelState.IsValid)
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


