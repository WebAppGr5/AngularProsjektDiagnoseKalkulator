using obligDiagnoseVerktøyy.Model.DTO;
using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Model.viewModels;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface IDiagnoseRepository
    {
         /**
         * Henter diagnose. Ment å brukes i listing
         */
        public Task<List<DiagnoseListModel>> hentDiagnoser();
 
         /**
         * Et symptombilde peker kun på en diagnose, mens flere symptombilder kan gi samme diagnose.
         * Viktige her er å bare retunere unike elementer.
         * 
         * Ment å brukes i listing
         */
        public Task<List<DiagnoseListModel>> hentDiagnoser(List<SymptomBilde> symptomBilder);

        /**
         *   Diagnoser gitt gruppe id. Ment å brukes i listing
         */
        public Task<List<DiagnoseListModel>> hentDiagnoser(int diagnoseGruppeId);

        /**
         *  Sletter diagnose med denne id
         */
        public void deleteDiagnose(int diagnoseId);

        /**
         * Oppdaterer denne diagnose
         */
        public void update(Diagnose diagnose);
        /**
         * Lager diagnose, med all diagnose data tilgjengelig
         */
        public void Add(Diagnose diagnose);
        /**
         * Lager diagnose, med utvalg av data gitt fra brukeren (som i dette tilfellet er lik diagnose)
         */
        public void addDiagnose(DiagnoseCreateDTO diagnoseDto);

        /**
         *  Henter diagnose gitt id. Ment å brukes i listing
         */
        public Task<DiagnoseDetailModel> hentDiagnoseGittDiagnoseId(int diagnoseId);


    }
}