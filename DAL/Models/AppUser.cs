using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace DAL.Models
{
	public class AppUser : IdentityUser
	{
		[Required]
		public required string FirstName { get; set; }

		[Required]
		public required string LastName { get; set; }

		[Required]
		public required string Gender { get; set; }

		public string? City { get; set; }

		[Range(5, 120, ErrorMessage = "Please enter a valid age between 5 and 120.")]
		public int Age { get; set; }

		[Range(50, 300, ErrorMessage = "Please enter a valid height between 50 cm and 300 cm.")]
		public int Height { get; set; }

		[Range(1, 300, ErrorMessage = "Please enter a valid weight up to 300 kg.")]
		public int Weight { get; set; }

		public float NeckCircumference { get; set; } = 0;
		public float PecsCircumference { get; set; } = 0;
		public float WaistCircumference { get; set; } = 0;
		public float StomachCircumference { get; set; } = 0;
		public float HipsCircumference { get; set; } = 0;
		public float ThighsCircumference { get; set; } = 0;
		public float ArmCircumference { get; set; } = 0;
		public float BodyFatPrecentage { get; set; } = 0;

		public bool AgreedToTerms { get; set; } = false;

        //Foreign Keys:
        public int? HealthDeclarationId { get; set; }

        //Navigation props:
        public HealthDeclaration HealthDeclaration { get; set; }
		public List<Plan> Plans { get; set; } = [];
    }
}
