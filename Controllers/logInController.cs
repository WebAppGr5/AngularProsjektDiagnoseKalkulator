using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using obligDiagnoseVerktøyy.Repository.interfaces;
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
    

    }
}


