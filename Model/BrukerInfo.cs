using symptkalk.model;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace symptkalk.Model
{
    [ExcludeFromCodeCoverage]
    //Lager modell for personlig info om bruker
    public class BrukerInfo
    {
        [Key]
        [RegularExpression(@"[\d-]{4}")]
        public int ID { get; set; }

        [RegularExpression(@"[a-zA-zæøåÆØÅ. \-]{3,20}")]
        public string Fornavn { get; set; }

        [RegularExpression(@"[a-zA-zæøåÆØÅ.\-]{3,30}")]
        public string etternavn { get; set; }

         public  BrukerLogIn brukerLogin { get; set; }
        
        
    }
}