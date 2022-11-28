
using System.ComponentModel.DataAnnotations;

namespace obligDiagnoseVerktøyy.Model.DTO
{
    public class BrukerLogin
    {
        public string brukernavn { get; set; }
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,30}$")]
        public string passord { get; set; }
    }
}