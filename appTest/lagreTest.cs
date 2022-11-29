using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace lagreTest {
    public class lagreTest{
        private const string _lagret = "lagret"
        private const string _ikkeLagret = "";
        private const string _LoggetInn = "Logget";
        private const string _ikkeLoggetInn = "";
        private readonly Mock<IBrukerRepository> mockRep = new Mock<IBrukerRepository>;
        private readonly Mock<ILogger<logInController>> mockLog = new Mock<ILogger<logInController>>();

        private readonly Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
        private readonly MockHttpSession mockSession = new MockHttpSession();

        [Fact]
        public async Task LagreComponent(){
            var Component1 = new diagnose{ID=1112, symptomGrupper= 3, harLagret=false, error = false, erInnlogget=true, optionsVarighet="Flere dager"};
            var Component2 = new diagnose{ID=1212, symptomGrupper= 2, harLagret=false, error = false, erInnlogget=true, optionsVarighet="1-3 dager"};

            var componentListe = new List<LagreComponent>();
            componentListe.Add(Component1);
            componentListe.Add(Component2);

            mockRep.Setup(i => i.HentAlle()).ReturnAsync(componentListe);
            var DiagnoseController = new DiagnoseController(mockRep.Object, mockLog.Object);
             MockHttpSession[_LoggetInn] = _LoggetInn;
             mockHttpContext.Setup(sbyte => sbyte.Session).Returns(MockSession);
             DiagnoseController.ControllerContext.Http.Context = mockHttpContext.object;

             var result = await DiagnoseController.sjekkErInnlogget(It.IsAny<bool>()) as OkObjectResult;

             Assert.Equals((int)HttpStatusCode.OK, RequestSizeLimitAttribute.StatusCode);
             Assert.Equal<KeyNotFoundException>(Component1,(LagreComponent).result.Value);
        }

        [Fact]
        public async Task sjekkErInnlogget(){
            var result = await logInController.LogIn(It.IsAny<Bruker>()) as OkObjectResult;
            if (_loggetInn!=null){
                Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
                Assert.True((bool)result.Value);
            }
            else {
            Assert.False((bool)result.Value);
            }
        }
        [Fact]
        public async Task hentSymptomer(){
            var sympt1 = new Symptom{
            ID = 010,
            Symptom = "Hodepine"
            };
            mockRep.Setup(s => s.HentEn(It.IsAny<int>())).ReturnsAsync(sympt1);
            var DiagnoseController = new DiagnoseController(mockRep.Object, mockLog.Object);

            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            DiagnoseController.Controller.ControllerContext.HttpContext = mockHttpContext.Object;
        }
        [Fact]
        public async Task lagreOK(){
            mockRep.Setup(d => d.Lagre(It.IsAny<Symptom>())).ReturnsAsync(true);
            var DiagnoseController = new DiagnoseController(mockRep.Object,mockLog.Object);

            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            DiagnoseController.ControllerContext.HttpContext = mockHttpContext.Object;

            var result = await DiagnoseController.Lagre(It.IsAny<Diagnose>()) as OkObjectResult;
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("Diagnose Lagret", resultat.Value);
        }
        [Fact]
        public async Task hentSymptomGrupper(){
            var sg1 = new SymptomGruppe{
                        ID = 04
                        Symptomer[] = "Hodepine, vondt i mage, hoven hals",
                        };
            mockRep.Setup(s => s.HentAlle(It.IsAny<int>())).ReturnsAsync(sg1);
            var DiagnoseController = new DiagnoseController(mockRep.Object, mockLog.Object);

            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            DiagnoseController.Controller.ControllerContext.HttpContext = mockHttpContext.Object;
        }
    }
}
*/