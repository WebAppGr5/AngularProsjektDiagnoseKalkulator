using System.Collections.Generic;
using System.Threading.Tasks;
using ClientApp.Model;

namespace ClientApp.DAL{
public interface IBrukerRepository{
Task<bool>Lagre(Bruker innBruker);
Task<List<Bruker>> hentAlle();
Task<bool>LoggInn(Bruker bruker);

}
}