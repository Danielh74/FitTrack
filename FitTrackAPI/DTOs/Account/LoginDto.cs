using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.Account
{
	public class LoginDto
	{
		[Required]
		[EmailAddress]
		public string? Email { get; set; }

		[Required]
		public string? Password { get; set; }
	}
}
