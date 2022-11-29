using System.Collections.Generic;
using System.Threading.Tasks;
using obligDiagnoseVerktøyy.Model.entities; 

namespace diagnoseKalkulatorAngular.Repository.interfaces
{
    public interface IBrukerRepository
    {
        public Task<bool> Lagre(Brukerpersonalia innBruker);
        public Task<List<Bruker>> hentAlle();
        public Task<bool> LoggInn(Bruker bruker);

    }
}