using System.Collections.Generic;
using System.Threading.Tasks;
using obligDiagnoseVerktøyy.Model.entities; 

namespace diagnoseKalkulatorAngular.Repository.interfaces
{
    public interface IBrukerRepository
    {

        public Task<bool> LoggInn(Bruker bruker);
        public byte[] lagSalt();
        public byte[] lagHash(string passord, byte[] salt);

    }
}