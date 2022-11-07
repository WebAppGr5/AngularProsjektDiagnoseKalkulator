using System.ComponentModel.DataAnnotations;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class SymptomGruppeListModel
    {
        public int symptomGruppeId { get; set; }
        public string navn { get; set; } //Forklaringen kan hentes ut herfra

        public string beskrivelse { get; set; } //Forklaringen kan hentes ut herfra

    }
}
