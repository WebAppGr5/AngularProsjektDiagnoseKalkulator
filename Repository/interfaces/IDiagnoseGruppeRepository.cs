using obligDiagnoseVerktøyy.Model.entities;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface IDiagnoseGruppeRepository
    {

        /**
         * Henter diagnose grupper. Ment å brukes i listing
         */
        public Task<List<DiagnoseGruppeListModel>> hentDiagnoseGrupper();


    }
}