using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace getDiagnoseTest{
public class getDiagnoseTest{
    private readonly Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
    private readonly MockHttpSession mockSession = new MockHttpSession();

    [Fact]
    public async Task getSymptomer{
    var sympt1 = new Symptom{
         ID = 055,
         Symptom = "tett nese",
         varighet = "1-3 dager",
    };
    var sympt2 = new Symptom{
        ID = 032,
        Symptom = "vondt i mage",
        varighet = "flere dager",
    }
        var symptListe = new List<Symptomer>();
        brukerListe.Add(sympt1);
        brukerListe.Add(sympt2);
         mockRep.Setup(s => s.HentAlle(It.IsAny<int>())).ReturnsAsync(symptListe);
         var DiagnoseController = new DiagnoseController(mockRep.Object, mockLog.Object);

         mockHttpContext.Setup(s => s.Session).Returns(mockSession);
         DiagnoseController.Controller.ControllerContext.HttpContext = mockHttpContext.Object;
    }

    [Fact]
    public async Task getSymptGruppe{
    var sg1 = new SymptomGruppe{
          ID = 07
          Symptomer[] = "001, 020, 039",
          };
          mockRep.Setup(s => s.HentAlle(It.IsAny<int>())).ReturnsAsync(sg1);
          var DiagnoseController = new DiagnoseController(mockRep.Object, mockLog.Object);

          mockHttpContext.Setup(s => s.Session).Returns(mockSession);
          DiagnoseController.Controller.ControllerContext.HttpContext = mockHttpContext.Object;
    }

    [Fact]
    public async Task getDiagose{
        var diag = new Diagnose{
        ID = 02,
        Navn = "Migrene",
        }
        mockRep.Setup(d => d.HentEn(It.IsAny<string>())).ReturnsAsync(diag);
        var DiagnoseController = new DiagnoseController(mockRep.Object, mockLog.Object);

        mockHttpContext.Setup(s => s.Session).Returns(mockSession);
        DiagnoseController.Controller.ControllerContext.HttpContext = mockHttpContext.Object;
    }
}
}