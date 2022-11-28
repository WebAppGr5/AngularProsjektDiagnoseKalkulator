using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ClientApp.Model
{
    [ExcludeFromCodeCoverage]
    //Lager modell for personlig info om bruker
    public class BrukerInfo
    {
        [Key]
        [RegularExpression(@"[\d-]{4}")]
        public int ID { get; set; }

        [RegularExpression(@"[a-zA-z .\-]{3,20}")]
        public string Fornavn { get; set; }

        [RegularExpression(@"[a-zA-z .\-]{3,30}")]
        public string etternavn { get; set; }

        [RegularExpression(@"[a-zA-z.\-]{3,30}")]
		public string brukernavn { get; set; }
		[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,30}$")]
		public string passord { get; set; }

         public  BrukerLogIn brukerLogin { get; set; }
        
        
    }
}