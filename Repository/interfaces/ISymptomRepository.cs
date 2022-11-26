using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Model.viewModels;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface ISymptomRepository
    {
        /**
         *  Henter symptom gitt symptom id. Ment å brukes i detaljert visning
         */
        public Task<SymptomDetailModel> hentSymptomGittSymptomId(int symptomId);

        /**
         *  Henter symptomer. Ment å brukes i lister
         */
        public Task<List<SymptomListModel>> hentSymptomer();
        /**
        *  Henter symptomer, gitt symptomgruppe id Ment å brukes i lister
        */
        public Task<List<SymptomListModel>> hentSymptomer(int symptomGruppeId);
    }
}