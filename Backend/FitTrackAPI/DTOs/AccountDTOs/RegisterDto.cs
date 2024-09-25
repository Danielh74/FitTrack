using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.AccountDTOs
{
	public class RegisterDto
	{
		[Required]
		[MinLength(2)]
		public string FirstName { get; set; } = string.Empty;

		[Required]
		[MinLength(2)]
		public string LastName { get; set; } = string.Empty;

		[Required]
		[Range(1, 120)]
		public int Age { get; set; }

		[Required]
		[MinLength(3)]
		public string Gender { get; set; } = string.Empty;

		[Required]
		[MinLength(3)]
		public string Goal { get; set; } = string.Empty;

		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; } = string.Empty;

		[Required]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Password does not match")]
		public string ValidatePassword { get; set; } = string.Empty;

		[Required]
        public bool AgreedToTerms { get; set; }
    }
}
