
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace obligDiagnoseVerktøyy.Model.entities
{
    [ExcludeFromCodeCoverage]

    public class Bruker
    {
        public int ID { get; set; }
        public string brukernavn { get; set; }
        public string passord { get; set; }
        public string salt { get; set; }

    }
}