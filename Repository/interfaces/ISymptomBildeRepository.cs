using obligDiagnoseVerktøyy.Model.DTO;
using obligDiagnoseVerktøyy.Model.entities;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface ISymptomBildeRepository
    {

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
         *  Ment å brukes som et mellomsteg, som en kalkulering
         */
        public Task<List<SymptomBilde>> hentSymptomBilder(List<SymptomDTO> symptomIdEnTrenger);

    }
}