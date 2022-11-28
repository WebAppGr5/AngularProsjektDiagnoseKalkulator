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
        private readonlu MockHttpSession = new MockHttpSession();

    [Fact]
    public async Task HentAlleLoggetInnOK(){
        var bruker1 = new BrukerInfo {ID = 1,Fornavn="Ola",etternavn="Nordmann",brukernavn="OlaNordmann@mail.no",passord="123AbC"};
        var bruker2 = new BrukerInfo {ID = 2, Fornavn="Elene",etternavn="Nydal", brukernavn="Elene23@service.com",passord="GulBall43"};
    
    var brukerListe = new List<BrukerInfo>();
    brukerListe.Add(bruker1);
    brukerListe.Add(bruker2);

    mockRep.Setup(i => i.HentAlle()).ReturnAsync(brukerListe);

    var brukercontroller = new brukercontroller(mockRep.Object, mockLog.Object);

    
    }

    }
}*/