
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace obligDiagnoseVerktøyy.Model.DTO
{
    [ExcludeFromCodeCoverage]

    public class BrukerPersonalia
    {
        [RegularExpression(@"[a-zA-z .\-]{3,20}")]
        public string fornavn { get; set; }

        [RegularExpression(@"[a-zA-z .\-]{3,30}")]
        public string etternavn { get; set; }



    }
}