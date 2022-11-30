/**;
using System.Collections.Generic
using System.Net;
using System.Threading.Tasks;
using symptkalk.controller;
using ClientApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace symptkalk.test{
    public class SymptkalkTest{
         private const string _LoggetInn = "Logget";
        private const string _ikkeLoggetInn = "";

        private readonly Mock<IBrukerRepository> mockRep = new Mock<IBrukerRepository>;
        private readonly Mock<ILogger<brukercontroller>> mockLog = new Mock<ILogger<logInController>>();

        private readonly Mock HttpContext> mockHttpContext = new Mock<HttpContext>();
        private readonly MockHttpSession = new MockHttpSession();

    [Fact]
    public async Task HentAlleLoggetInnOK(){
        var bruker1 = new BrukerInfo {ID = 1,Fornavn="Ola",etternavn="Nordmann",brukernavn="OlaNordmann@mail.no",passord="123AbC"};
        var bruker2 = new BrukerInfo {ID = 2, Fornavn="Elene",etternavn="Nydal", brukernavn="Elene23@service.com",passord="GulBall43"};
    
    var brukerListe = new List<BrukerInfo>();
    brukerListe.Add(bruker1);
    brukerListe.Add(bruker2);

    mockRep.Setup(i => i.HentAlle()).ReturnAsync(brukerListe);

    var logInController = new logInController(mockRep.Object, mockLog.Object);

    MockHttpSession[_LoggetInn] = _LoggetInn;
    mockHttpContext.Setup(sbyte => sbyte.Session).Returns(MockSession);
    brukercontroller.ControllerContext.Http.Context = mockHttpContect.object;

    var result = await logInController.HentEn(It.IsAny<int>()) as OkObjectResult;
    
    Assert.Equals((int)HttpStatusCode.OK, RequestSizeLimitAttribute.StatusCode);
    Assert.Equal<KeyNotFoundException>(bruker1,(Bruker).resultat.Value);
    }

    [Fact]
    public async Task HentEnIkkeOK{
        mockRep.Setup(int => int.HentEn(It.IsAny<int>)).ReturnAsync(()=>null);

        var logInController = new logInController(mockRep.Object,mockog.Object);

        mockSession[_LoggetInn] = _LoggetInn;
        mockHttpContext.Setup(s => s.Session).Returns(mockSession);
        logInController.ControllerContext.HttpContext = mockHttpContext.Object;

        var resultat = await logInController.HentEn(It.IsAny<int>()) as NotFoundObjectResult;

        Assert.Equal((int)HTTPStatusCode.OK, result.StatusCode);
        Assert.Equal("Fant ikke brukeren", result.Value);
    }

    [Fact]
    public async Task EndreLoggetInnOK(){
        mockRep.Setup(b => b.Endre(It.IsAny<bruker>())).ReturnsAsync(true);

            var logInController = new logInController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            logInController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var result = await logInController.Endre(It.IsAny<bruker>()) as OkObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("Bruker endret", result.Value);
    }

     [Fact]
        public async Task EndreLoggetInnIkkeOK()
        {
            // Arrange

            mockRep.Setup(b => b.Lagre(It.IsAny<bruker>())).ReturnsAsync(false);

            var logInController = new logInController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            logInController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var result = await logInController.Endre(It.IsAny<bruker>()) as NotFoundObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            Assert.Equal("Endringen av brukeren kunne ikke utføres", result.Value);
        }



     [Fact]
        public async Task LoggInnOK()
        {
            mockRep.Setup(b => b.LoggInn(It.IsAny<Bruker>())).ReturnsAsync(true);

            var logInController = new logInController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            logInController.ControllerContext.HttpContext = mockHttpContext.Object;

            var resultat = await logInController.LoggInn(It.IsAny<Bruker>()) as OkObjectResult;

            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.True((bool)resultat.Value);
        }

        [Fact]
        public async Task LoggInnFeilPassordEllerBruker()
        {
            mockRep.Setup(b => b.LoggInn(It.IsAny<Bruker>())).ReturnsAsync(false);

            var logInController = new logInController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _ikkeLoggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            logInController.ControllerContext.HttpContext = mockHttpContext.Object;

            var resultat = await logInController.LoggInn(It.IsAny<Bruker>()) as OkObjectResult;

            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.False((bool)resultat.Value);
        }

        [Fact]
        public async Task LoggInnInputFeil()
        {
            mockRep.Setup(b => b.LoggInn(It.IsAny<Bruker>())).ReturnsAsync(true);

            var logInController = new logInController(mockRep.Object, mockLog.Object);

            logInController.ModelState.AddModelError("Feil i inputvalidering på server");

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            logInController.ControllerContext.HttpContext = mockHttpContext.Object;

            var resultat = await logInController.LoggInn(It.IsAny<Bruker>()) as BadRequestObjectResult;

            Assert.Equal((int)HttpStatusCode.BadRequest, resultat.StatusCode);
            Assert.Equal("Feil i inputvalidering på server", resultat.Value);
        }
        [Fact]
        public void LoggUt()
        {
            var logInController = new logInController(mockRep.Object, mockLog.Object);
            
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            mockSession[_loggetInn] = _loggetInn;
            logInController.ControllerContext.HttpContext = mockHttpContext.Object;
         
            // Act
            logInController.LoggUt();

            // Assert
           Assert.Equal(_ikkeLoggetInn,mockSession[_loggetInn]);
        }
    }
}*/