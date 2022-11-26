using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Model.viewModels;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface ISymptomGruppeRepository
    {

        /**
         *  Henter symptom grupper. Ment å brukes i liste visning
         */
        public Task<List<SymptomGruppeListModel>> hentSymptomGrupper();

        /**
         *  Henter symptomgrupper gitt gruppe id. Ment å brukes i detaljert visning
         */
        public Task<SymptomGruppeDetailModel> hentSymptomGruppeGittSymptomGruppeId(int symptomGruppeId);
    }
}