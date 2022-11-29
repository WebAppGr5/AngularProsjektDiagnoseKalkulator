using System.Collections.Generic;
using System.Threading.Tasks;
using obligDiagnoseVerkt�yy.Model.entities; 

namespace diagnoseKalkulatorAngular.Repository.interfaces
{
    public interface IBrukerRepository
    {

        public Task<bool> LoggInn(Bruker bruker);

    }
}