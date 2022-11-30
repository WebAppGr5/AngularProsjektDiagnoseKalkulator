using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Identity;

using Microsoft.Extensions.WebEncoders.Testing;
using Microsoft.VisualBasic;
using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Repository.interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//using System.Web.Mcv;
//using System.Web.Mcv.Ajax;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using obligDiagnoseVerktøyy.Repository.implementation;
using Microsoft.Extensions.Logging;
using obligDiagnoseVerktøyy.Model.DTO;
using System.Data.SqlTypes;
using obligDiagnoseVerktøyy.Model.viewModels;
private Mock<IDiagnoseGruppeRepository> _diagnoseGruppeRepository;
private Mock<IDiagnoseRepository> _diagnoseRepository;
private Mock<ISymptomGruppeRepository> _symptomGruppeRepository;
private Mock<ISymptomBildeRepository> _symptomBildeRepository;
private Mock<ISymptomRepository> _symptomRepository;
private const string _loggetInn = "loggetInn";
private const string _ikkeLoggetInn = "";

private  Mock<ILogger<DiagnoseController>> _mockLog;

private  Mock<HttpContext> mockHttpContext;
private  MockHttpSession mockSession = new MockHttpSession();

namespace obligDiagnoseVerktøyy.Controllers.implementations
{
    [Route("[controller]/[action]")]
    public class DiagnoseController : ControllerBase
    {
        private IDiagnoseRepository _diagnoseRepository;
        private IDiagnoseGruppeRepository _diagnoseGruppeRepository;
        private ISymptomBildeRepository _symptomBildeRepository;
        private ISymptomGruppeRepository _symptomGruppeRepository;
        private ISymptomRepository _symptomRepository;

        private ILogger<DiagnoseController> _logger;
        private const string _loggetInn = "InnLogget";
        private const string _ikkeLoggetInn = "";

        public DiagnoseController(IDiagnoseRepository diagnoseRepository, IDiagnoseGruppeRepository diagnoseGruppeRepository, ISymptomBildeRepository symptomBildeRepository, ISymptomGruppeRepository symptomGruppeRepository, ISymptomRepository symptomRepository, ILogger<DiagnoseController> logger)
        {
            _diagnoseGruppeRepository = new Mock<IDiagnoseGruppeRepository>();
                        _diagnoseRepository = new Mock<IDiagnoseRepository>();
                        _symptomGruppeRepository = new Mock<ISymptomGruppeRepository>();
                        _symptomBildeRepository = new Mock<ISymptomBildeRepository>();
                        _symptomRepository = new Mock<ISymptomRepository>();
                        _mockLog = new Mock<ILogger<DiagnoseController>>();
                        mockHttpContext = new Mock<HttpContext>();
                        mockSession = new MockHttpSession();


                        var DiagnoseController = new DiagnoseController(_diagnoseRepository.Object, _diagnoseGruppeRepository.Object, _symptomBildeRepository.Object, _symptomGruppeRepository.Object, _symptomRepository.Object, _mockLog.Object);
            this._logger = logger;
            this._diagnoseRepository = diagnoseRepository;
            this._diagnoseGruppeRepository = diagnoseGruppeRepository;
            this._symptomBildeRepository = symptomBildeRepository;
            this._symptomGruppeRepository = symptomGruppeRepository;
            this._symptomRepository = symptomRepository;
        }




        [HttpDelete("{id}")]
        /**
         *  Sletter diagnose med gitt id
         */
        public async Task<IActionResult> forgetDiagnose([FromRoute] int id)
        {
        _diagnoseGruppeRepository = new Mock<IDiagnoseGruppeRepository>();
                    _diagnoseRepository = new Mock<IDiagnoseRepository>();
                    _symptomGruppeRepository = new Mock<ISymptomGruppeRepository>();
                    _symptomBildeRepository = new Mock<ISymptomBildeRepository>();
                    _symptomRepository = new Mock<ISymptomRepository>();
                    _mockLog = new Mock<ILogger<DiagnoseController>>();
                    mockHttpContext = new Mock<HttpContext>();
                    mockSession = new MockHttpSession();


                    var DiagnoseController = new DiagnoseController(_diagnoseRepository.Object, _diagnoseGruppeRepository.Object, _symptomBildeRepository.Object, _symptomGruppeRepository.Object, _symptomRepository.Object, _mockLog.Object);



           if (string.IsNullOrEmpty((HttpContext.Session.GetString(_loggetInn))))
            {
                return Unauthorized("Ikke logget inn");
           }


            if (id < 0)
            {
                _logger.LogInformation("Bad id input");
                return BadRequest("Bad id input");
            }
            try
            {

                _diagnoseRepository.deleteDiagnose(id);
                _logger.LogInformation("Diagnose med id " + id + " er slettet");
                return Ok(1);
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogError("bad id");
                return NotFound("bad id");
            }
            catch (Exception ex)
            {
                _logger.LogError("Kunne ikke slette diagnosen");
                return BadRequest();
            }
        }

        [HttpPut]
        /**
         *  Oppdaterer diagnose med info tilsvarende DiagnoseChangeDTO diagnose
         */
        public async Task<IActionResult> update([FromBody] DiagnoseChangeDTO diagnose)
        {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))

            {
                return Unauthorized("Ikke logget inn");
           }

            if (ModelState.IsValid)
            {

                try
                {
                    Diagnose diagnosen = new Diagnose
                    {
                        beskrivelse = diagnose.beskrivelse,
                        diagnoseGruppe = null,
                        diagnoseGruppeId = -1,
                        diagnoseId = diagnose.diagnoseId,
                        dypForklaring = diagnose.dypForklaring,
                        navn = diagnose.navn,
                        symptomBilde = null
                    };
                    _diagnoseRepository.update(diagnosen);
                    _logger.LogInformation("Diagnose med id " + diagnose.diagnoseId + " er oppdatert til " + diagnose.ToString());
                    return Ok(1);
                }
                catch (EntityNotFoundException ex)
                {
                    _logger.LogError("bad id");
                    return NotFound("bad id");
                }
                catch (Exception ex)
                {

                    _logger.LogError("Could not change diagnose");
                    return BadRequest(new List<Diagnose>());
                }
            }
            else
            {
                _logger.LogInformation("diagnose got bad server input");
                return BadRequest("diagnose got bad server input");
            }
        }

        [HttpGet("{id}")]
        /**
         *  Henter diagnose med gitt id
         */
        public async Task<IActionResult> hentDiagnoseGittDiagnoseId([FromRoute] int id)
        {
        _diagnoseGruppeRepository = new Mock<IDiagnoseGruppeRepository>();
                    _diagnoseRepository = new Mock<IDiagnoseRepository>();
                    _symptomGruppeRepository = new Mock<ISymptomGruppeRepository>();
                    _symptomBildeRepository = new Mock<ISymptomBildeRepository>();
                    _symptomRepository = new Mock<ISymptomRepository>();
                    _mockLog = new Mock<ILogger<DiagnoseController>>();
                    mockHttpContext = new Mock<HttpContext>();
                    mockSession = new MockHttpSession();


                    var DiagnoseController = new DiagnoseController(_diagnoseRepository.Object, _diagnoseGruppeRepository.Object, _symptomBildeRepository.Object, _symptomGruppeRepository.Object, _symptomRepository.Object, _mockLog.Object);
            if (id < 0)
            {
                _logger.LogError("Bad id input");
                return BadRequest("Bad id input");
            }

            try
            {
                DiagnoseDetailModel diagnose = await _diagnoseRepository.hentDiagnoseGittDiagnoseId(id);
                _logger.LogInformation("Did get diagnose with  id " + id);
                return Ok(diagnose);
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogError("bad id");
                return NotFound("bad id");
            }
            catch (Exception ex)
            {

                _logger.LogError("Kunne ikke hente diagnose");
                return BadRequest("Kunne ikke hente diagnose");
            }
        }
        [HttpGet("{id}")]
        /**
         *  Henter symptomer med gitt id
         */
        public async Task<IActionResult> hentSymptomGittSymptomId([FromRoute] int id)
        {
        _diagnoseGruppeRepository = new Mock<IDiagnoseGruppeRepository>();
                    _diagnoseRepository = new Mock<IDiagnoseRepository>();
                    _symptomGruppeRepository = new Mock<ISymptomGruppeRepository>();
                    _symptomBildeRepository = new Mock<ISymptomBildeRepository>();
                    _symptomRepository = new Mock<ISymptomRepository>();
                    _mockLog = new Mock<ILogger<DiagnoseController>>();
                    mockHttpContext = new Mock<HttpContext>();
                    mockSession = new MockHttpSession();


                    var DiagnoseController = new DiagnoseController(_diagnoseRepository.Object, _diagnoseGruppeRepository.Object, _symptomBildeRepository.Object, _symptomGruppeRepository.Object, _symptomRepository.Object, _mockLog.Object);
            if (id < 0)
            {
                _logger.LogError("Bad id input");
                return BadRequest("Bad id input");
            }
            try
            {
                SymptomDetailModel symptom = await _symptomRepository.hentSymptomGittSymptomId(id);
                _logger.LogInformation("Did get symptom with  id " + id);
                return Ok(symptom);
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogError("bad id");
                return NotFound("bad id");
            }
            catch (Exception ex)
            {

                _logger.LogError("Klarte ikke å hente symptom");
                return BadRequest("Klarte ikke å hente symptom");
            }
        }

        [HttpGet("{id}")]
        /**
         *  Henter symptomer med gitt gruppe id
         */
        public async Task<IActionResult> hentSymptomGruppeGittSymptomGruppeId([FromRoute] int id)
        {
        _diagnoseGruppeRepository = new Mock<IDiagnoseGruppeRepository>();
                    _diagnoseRepository = new Mock<IDiagnoseRepository>();
                    _symptomGruppeRepository = new Mock<ISymptomGruppeRepository>();
                    _symptomBildeRepository = new Mock<ISymptomBildeRepository>();
                    _symptomRepository = new Mock<ISymptomRepository>();
                    _mockLog = new Mock<ILogger<DiagnoseController>>();
                    mockHttpContext = new Mock<HttpContext>();
                    mockSession = new MockHttpSession();


                    var DiagnoseController = new DiagnoseController(_diagnoseRepository.Object, _diagnoseGruppeRepository.Object, _symptomBildeRepository.Object, _symptomGruppeRepository.Object, _symptomRepository.Object, _mockLog.Object);
            if (id < 0)
            {
                _logger.LogInformation("Bad id input");
                return BadRequest("Bad id input");
            }
            try
            {
                SymptomGruppeDetailModel symptomgruppe =
                    await _symptomGruppeRepository.hentSymptomGruppeGittSymptomGruppeId(id);
                _logger.LogInformation("Did get symptom group with id " + id);
                return Ok(symptomgruppe);
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogError("bad id");
                return NotFound("bad id");
            }
            catch (Exception ex)
            {

                _logger.LogError("Klarte ikke å hente symptom gruppe");
                return BadRequest("Kunne ikke hente symptom gruppe");
            }
        }

        [HttpPost]
        /**
         *  Lager ny diagnose med innhold fra  DiagnoseCreateDTO diagnose
         */
        public async Task<IActionResult> nyDiagnose([FromBody] DiagnoseCreateDTO diagnose)
        {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))

            {
                return Unauthorized("Ikke logget inn");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (diagnose.symptomer.Count != diagnose.varigheter.Count || diagnose.symptomer.Count == 0)
                    {
                        _logger.LogInformation("diagnose got bad server input");
                        return BadRequest("diagnose got bad server input");
                    }
                    _diagnoseRepository.addDiagnose(diagnose);
                    _logger.LogInformation("Created new diagnose equal to " + diagnose.ToString());
                    return  Ok(1);
                }
                catch (EntityNotFoundException ex)
                {
                    _logger.LogError("bad id");
                    return NotFound("bad id");
                }
                catch (Exception ex)
                {

                    _logger.LogError("Klarte ikke å lage diagnose");
                    return BadRequest(new List<Diagnose>());
                }
            }
            else
            {
                _logger.LogInformation("diagnose got bad server input");
                return BadRequest("diagnose got bad server input");
            }


        }


        [HttpPost]
        /**
       *  Ulike symptombilder består av ulike symptomer. SymptomDTO består av liste av varigheter og symptomer.
       *  Hvert symptom har en varighet. Hvis symptomet befant seg i posisjon J i symptomlisten, så 
       *  befinner varigheten assosiert med dette symptomet i posisjon J i listen over varigheter.
       *  
       *  Så lenge symptomSymtombilde (en mange til mange, med symptom i posisjon J) har en varighet større eller lik
       *  varigheten i posisjon J i varighet listen, så vil symptombilde være med i listen.
       *  
       *  Symptombilder uten symptomer som er i listen som kommer inn, blir ikke med i retunert liste.
       *  Dvs, at tom liste av symptomer, medfører at ingenting blir retunert.
       *  
       */
        public async Task<IActionResult> getDiagnoserGittSymptomer([FromBody] List<SymptomDTO> symptomliste)
        {
        _diagnoseGruppeRepository = new Mock<IDiagnoseGruppeRepository>();
                    _diagnoseRepository = new Mock<IDiagnoseRepository>();
                    _symptomGruppeRepository = new Mock<ISymptomGruppeRepository>();
                    _symptomBildeRepository = new Mock<ISymptomBildeRepository>();
                    _symptomRepository = new Mock<ISymptomRepository>();
                    _mockLog = new Mock<ILogger<DiagnoseController>>();
                    mockHttpContext = new Mock<HttpContext>();
                    mockSession = new MockHttpSession();


                    var DiagnoseController = new DiagnoseController(_diagnoseRepository.Object, _diagnoseGruppeRepository.Object, _symptomBildeRepository.Object, _symptomGruppeRepository.Object, _symptomRepository.Object, _mockLog.Object);

            try
            {

                if (symptomliste.Count == 0)
                    return Ok(new List<DiagnoseListModel>());

                List<SymptomBilde> symptombilder = await _symptomBildeRepository.hentSymptomBilder(symptomliste);
                if (symptombilder.Count == 0)
                {
                    return Ok(new List<DiagnoseListModel>());
                }
                List<DiagnoseListModel> diagnoser = await _diagnoseRepository.hentDiagnoser(symptombilder);
                _logger.LogInformation("Returned list of symptomDTO with size " + symptomliste.Count);
                return Ok(diagnoser);
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogError("bad id");
                return NotFound("bad id");
            }
            catch (Exception ex)
            {
                _logger.LogError("Klarte ikke å konverte mellom listen over false/true kinda strenger for at et symptom er tilstede, til liste over diagnoser");
                return BadRequest(new List<Diagnose>());
            }
        }



        [HttpGet("{id}")]
        /**
         *  Symptomer gitt gruppe id
         */
        public async Task<IActionResult> getSymptomerGittGruppeId([FromRoute] int id)
        {
        _diagnoseGruppeRepository = new Mock<IDiagnoseGruppeRepository>();
                    _diagnoseRepository = new Mock<IDiagnoseRepository>();
                    _symptomGruppeRepository = new Mock<ISymptomGruppeRepository>();
                    _symptomBildeRepository = new Mock<ISymptomBildeRepository>();
                    _symptomRepository = new Mock<ISymptomRepository>();
                    _mockLog = new Mock<ILogger<DiagnoseController>>();
                    mockHttpContext = new Mock<HttpContext>();
                    mockSession = new MockHttpSession();


                    var DiagnoseController = new DiagnoseController(_diagnoseRepository.Object, _diagnoseGruppeRepository.Object, _symptomBildeRepository.Object, _symptomGruppeRepository.Object, _symptomRepository.Object, _mockLog.Object);
            if (id < 0)
            {
                _logger.LogError("Bad id input");
                return BadRequest("Bad id input");
            }
            try
            {
                List<SymptomListModel> symptomListe = await _symptomRepository.hentSymptomer(id);
                _logger.LogInformation("Returned list of SymptomListModel with id " + id + " size " + symptomListe.Count);
                return Ok(symptomListe);
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogError("bad id");
                return NotFound("bad id");
            }
            catch (Exception ex)
            {
                _logger.LogError("Kunne ikke hente symptomer gitt id");
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet]
        /**
         *   Alle diagnose grupper
         */
        public async Task<IActionResult> getDiagnoseGrupper()
        {
        _diagnoseGruppeRepository = new Mock<IDiagnoseGruppeRepository>();
                    _diagnoseRepository = new Mock<IDiagnoseRepository>();
                    _symptomGruppeRepository = new Mock<ISymptomGruppeRepository>();
                    _symptomBildeRepository = new Mock<ISymptomBildeRepository>();
                    _symptomRepository = new Mock<ISymptomRepository>();
                    _mockLog = new Mock<ILogger<DiagnoseController>>();
                    mockHttpContext = new Mock<HttpContext>();
                    mockSession = new MockHttpSession();


                    var DiagnoseController = new DiagnoseController(_diagnoseRepository.Object, _diagnoseGruppeRepository.Object, _symptomBildeRepository.Object, _symptomGruppeRepository.Object, _symptomRepository.Object, _mockLog.Object);
            try
            {
                List<DiagnoseGruppeListModel> diagnoseGruppe = await _diagnoseGruppeRepository.hentDiagnoseGrupper();
                _logger.LogInformation("Returned list of DiagnoseGruppe with size " + diagnoseGruppe.Count);
                return Ok(diagnoseGruppe);
            }

            catch (Exception ex)
            {
                _logger.LogError("Kunne ikke hente diagnose grupper");
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet]
        /**
         *  Alle symptomer
         */
        public async Task<IActionResult> getSymptomer()
        {
        _diagnoseGruppeRepository = new Mock<IDiagnoseGruppeRepository>();
                    _diagnoseRepository = new Mock<IDiagnoseRepository>();
                    _symptomGruppeRepository = new Mock<ISymptomGruppeRepository>();
                    _symptomBildeRepository = new Mock<ISymptomBildeRepository>();
                    _symptomRepository = new Mock<ISymptomRepository>();
                    _mockLog = new Mock<ILogger<DiagnoseController>>();
                    mockHttpContext = new Mock<HttpContext>();
                    mockSession = new MockHttpSession();


                    var DiagnoseController = new DiagnoseController(_diagnoseRepository.Object, _diagnoseGruppeRepository.Object, _symptomBildeRepository.Object, _symptomGruppeRepository.Object, _symptomRepository.Object, _mockLog.Object);
            try
            {
                List<SymptomListModel> symptomer = await _symptomRepository.hentSymptomer();
                _logger.LogInformation("Returned list of symptomer with size " + symptomer.Count);
                return Ok(symptomer);
            }

            catch (Exception ex)
            {
                _logger.LogError("Kunne ikke hente symptomer");
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet]
        /**
         *  Alle diagnoser
         */
        public async Task<IActionResult> getDiagnoser()
        {
        _diagnoseGruppeRepository = new Mock<IDiagnoseGruppeRepository>();
                    _diagnoseRepository = new Mock<IDiagnoseRepository>();
                    _symptomGruppeRepository = new Mock<ISymptomGruppeRepository>();
                    _symptomBildeRepository = new Mock<ISymptomBildeRepository>();
                    _symptomRepository = new Mock<ISymptomRepository>();
                    _mockLog = new Mock<ILogger<DiagnoseController>>();
                    mockHttpContext = new Mock<HttpContext>();
                    mockSession = new MockHttpSession();


                    var DiagnoseController = new DiagnoseController(_diagnoseRepository.Object, _diagnoseGruppeRepository.Object, _symptomBildeRepository.Object, _symptomGruppeRepository.Object, _symptomRepository.Object, _mockLog.Object);
            try
            {
                List<DiagnoseListModel> diagnoser = await _diagnoseRepository.hentDiagnoser();
                _logger.LogInformation("Returned list of diagnoser with size " + diagnoser.Count);
                return Ok(diagnoser);
            }

            catch (Exception ex)
            {
                _logger.LogError("Kunne ikke hente diagnoser");
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet("{id}")]
        /**
         *  Alle diagnoser gitt gruppe id
         */
        public async Task<IActionResult> getDiagnoserGittGruppeId([FromRoute] int id)
        {
        _diagnoseGruppeRepository = new Mock<IDiagnoseGruppeRepository>();
                    _diagnoseRepository = new Mock<IDiagnoseRepository>();
                    _symptomGruppeRepository = new Mock<ISymptomGruppeRepository>();
                    _symptomBildeRepository = new Mock<ISymptomBildeRepository>();
                    _symptomRepository = new Mock<ISymptomRepository>();
                    _mockLog = new Mock<ILogger<DiagnoseController>>();
                    mockHttpContext = new Mock<HttpContext>();
                    mockSession = new MockHttpSession();


                    var DiagnoseController = new DiagnoseController(_diagnoseRepository.Object, _diagnoseGruppeRepository.Object, _symptomBildeRepository.Object, _symptomGruppeRepository.Object, _symptomRepository.Object, _mockLog.Object);
            if (id < 0)
            {
                _logger.LogError("Bad id input");
                return BadRequest("Bad id input");
            }
            try
            {
                List<DiagnoseListModel> diagnoser = await _diagnoseRepository.hentDiagnoser(id);
                _logger.LogInformation("Returned list of diagnoser with id " + id + " and size " + diagnoser.Count);
                return Ok(diagnoser);
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogError("bad id");
                return NotFound("bad id");
            }
            catch (Exception ex)
            {
                _logger.LogError("Kunne ikke hente diagnoser gitt id");
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet]
        /**
         *  Alle symptom grupper
         */
        public async Task<IActionResult> getSymptomGrupper()
        {
        _diagnoseGruppeRepository = new Mock<IDiagnoseGruppeRepository>();
                    _diagnoseRepository = new Mock<IDiagnoseRepository>();
                    _symptomGruppeRepository = new Mock<ISymptomGruppeRepository>();
                    _symptomBildeRepository = new Mock<ISymptomBildeRepository>();
                    _symptomRepository = new Mock<ISymptomRepository>();
                    _mockLog = new Mock<ILogger<DiagnoseController>>();
                    mockHttpContext = new Mock<HttpContext>();
                    mockSession = new MockHttpSession();


                    var DiagnoseController = new DiagnoseController(_diagnoseRepository.Object, _diagnoseGruppeRepository.Object, _symptomBildeRepository.Object, _symptomGruppeRepository.Object, _symptomRepository.Object, _mockLog.Object);
            if (ModelState.IsValid)
            {
                try
                {
                    List<SymptomGruppeListModel> symptomGrupper = await _symptomGruppeRepository.hentSymptomGrupper();
                    _logger.LogInformation("Returned list of symptomGrupper with size " + symptomGrupper.Count);
                    return Ok(symptomGrupper);
                }

                catch (Exception ex)
                {
                    _logger.LogError("Kunne ikke hente symptom grupper");
                    return BadRequest("Something went wrong");
                }
            }
            else
            {
                _logger.LogInformation("Symptomgruppe got bad server input");
                return BadRequest("Symptomgruppe got bad server input");
            }

        }

    }


}
