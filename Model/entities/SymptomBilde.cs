﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class SymptomBilde
    {
        [Key]
        [RegularExpression(@"^[0-9]{1,6}$")]
        public int symptomBildeId { get; set; }

        [Required]
        [JsonIgnore]
        public List<SymptomSymptomBilde> symptomSymptomBilde { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{1,6}$")]
        public int diagnoseId { get; set; }


        [Required]
        [RegularExpression(@"^[a-zA-ZÆØÅæøå0-9\s-]{3,40}$")]
        public string navn { get; set; }


        [Required]
        [MaxLength(700)]

        public string beskrivelse { get; set; }


        [MaxLength(5000)]
        public String dypForklaring { get; set; }

        public Diagnose diagnose { get; set; }

    }
}