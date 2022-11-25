using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace symptkalk.Model
{
    [ExcludeFromCodeCoverage]
    public class BrukerInfo
    {
        [RegularExpression(@"[a-zA-zæøåÆØÅ. \-]{3,25}")]
        public int ID { get; set; }

        [RegularExpression(@"[a-zA-zæøåÆØÅ. \-]{3,20}")]
        public string Fornavn { get; set; }

        [RegularExpression(@"[a-zA-zæøåÆØÅ.\-]{3,30}")]
        public string etternavn { get; set; }
        
        
    }
}