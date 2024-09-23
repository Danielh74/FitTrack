using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.Account
{
	public class RegisterDto
	{
		[Required]
		[MinLength(2)]
		public string? FirstName { get; set; }

		[Required]
		[MinLength(2)]
		public string? LastName { get; set; }

		[Required]
		[Range(1, 120)]
		public int Age { get; set; }

		[Required]
		public string? Gender { get; set; }

		[Required]
		[EmailAddress]
		public string? Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string? Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Password does not match")]
		public string? ValidatePassword { get; set; }
	}
}
