
using System.ComponentModel.DataAnnotations;

namespace obligDiagnoseVerkt�yy.Model.DTO
{
    public class BrukerLogin
    {
        [MaxLength(50)]
        [MinLength(4)]
        public string brukernavn { get; set; }
        [MaxLength(50)]
        [MinLength(8)]
        public string passord { get; set; }
    }
}