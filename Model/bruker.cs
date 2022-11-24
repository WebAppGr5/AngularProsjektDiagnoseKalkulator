using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace symptkalk.Model
{
    [ExcludeFromCodeCoverage]
    public class BrukerInfo
    {
        public int ID { get; set; }
        [RegularExpression(@"[a-zA-zæøåÆØÅ. \-]{3,25}")]
        public string Fornavn { get; set; }
        [RegularExpression(@"[a-zA-zæøåÆØÅ. \-]{3,20}")]
        public string etternavn { get; set; }
        [RegularExpression(@"[a-zA-zæøåÆØÅ.\-]{3,30}")]
        
    }
}