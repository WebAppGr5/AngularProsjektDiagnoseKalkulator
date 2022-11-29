
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace obligDiagnoseVerktøyy.Model.entities
{
    [ExcludeFromCodeCoverage]

    public class Brukerpersonalia
    {
        [Key]
        [RegularExpression(@"[\d-]{4}")]
        public int ID { get; set; }
        [RegularExpression(@"[a-zA-z .\-]{3,20}")]
        public string fornavn { get; set; }

        [RegularExpression(@"[a-zA-z .\-]{3,30}")]
        public string etternavn { get; set; }



    }
}