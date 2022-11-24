using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using symptkalk.Model;

namespace symptkalk.controller
{
    [Route("[controller]/[action]")]
    public class logInController : ControllerBase
    {
        private IbrukerRepository _db;

        private ILogger<KundeController> _log;

        private const string _LoggetInn = "InnLogget";
        private const string _ikkeLoggetInn = "";

        public brukerController(IbrukerRepository db, ILogger<KundeController> log) 
        {
            _db = db;
            _log = log;
        }
    

    }
}


