using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using symptkalk.Model;

namespace symptkalk.model
{
	[ExcludeFromCodeCoverage]
	public class BrukerLogIn
	{
        [Key]
        [RegularExpression(@"[a-zA-zæøåÆØÅ.\-]{3,30}")]
		public string brukernavn { get; set; }
		[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,30}$")]
		public string passord { get; set; }
        public int ID { get; set; }
        public BrukerInfo brukerInfo { get; set; }

    }
}