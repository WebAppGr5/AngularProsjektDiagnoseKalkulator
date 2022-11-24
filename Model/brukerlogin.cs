using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace symptkalk.model
{
	[ExcludeFromCodeCoverage]
	public class brukerLogIn
	{
		[RegularExpression(@"[a-zA-zæøåÆØÅ.\-]{3,30}")]
		public string brukerN { get; set; }
		[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,30}$")]
		public string passord { get; set; }

	}
}