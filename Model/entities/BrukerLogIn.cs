
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace obligDiagnoseVerkt�yy.Model.entities
{
    [ExcludeFromCodeCoverage]
    //Lager modell for personlig info om bruker
    public class BrukerInfo
    {
        [Key]
        [RegularExpression(@"[\d-]{4}")]
        public int ID { get; set; }
        [RegularExpression(@"[a-zA-z.\-]{3,30}")]
		public string brukernavn { get; set; }
		[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,50}$")]
		public string passord { get; set; }


        
        
    }
}