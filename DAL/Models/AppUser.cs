using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace DAL.Models
{
	public class AppUser : IdentityUser
	{
		public string FirstName { get; set; } = string.Empty;

		public string LastName { get; set; } = string.Empty;

		public string Gender { get; set; } = string.Empty;

		public string City { get; set; } = string.Empty;
		public string Goal { get; set; } = string.Empty;

        [Range(5, 120, ErrorMessage = "Please enter a valid age between 5 and 120.")]
		public int Age { get; set; }

		[Range(50, 300, ErrorMessage = "Please enter a valid height between 50 cm and 300 cm.")]
		public int Height { get; set; }

		[Range(0, 300, ErrorMessage = "Please enter a valid weight up to 300 kg.")]
		public double Weight { get; set; }

		[Range(0, double.MaxValue, ErrorMessage = "Only positive inputs are allowed")]
		public double NeckCircumference { get; set; } = 0;

		[Range(0, double.MaxValue, ErrorMessage = "Only positive inputs are allowed")]
		public double PecsCircumference { get; set; } = 0;

		[Range(0, double.MaxValue, ErrorMessage = "Only positive inputs are allowed")]
		public double WaistCircumference { get; set; } = 0;

		[Range(0, double.MaxValue, ErrorMessage = "Only positive inputs are allowed")]
		public double AbdominalCircumference { get; set; } = 0;

		[Range(0, double.MaxValue, ErrorMessage = "Only positive inputs are allowed")]
		public double HipsCircumference { get; set; } = 0;

		[Range(0, double.MaxValue, ErrorMessage = "Only positive inputs are allowed")]
		public double ThighsCircumference { get; set; } = 0;

		[Range(0, double.MaxValue, ErrorMessage = "Only positive inputs are allowed")]
		public double ArmCircumference { get; set; } = 0;

		[Range(0, double.MaxValue, ErrorMessage = "Only positive inputs are allowed")]
		public double BodyFatPrecentage { get; set; } = 0;

		public bool AgreedToTerms { get; set; } = false;

        //Foreign Keys:
        public int? HealthDeclarationId { get; set; }
        public int? MenuId { get; set; }

        //Navigation props:
        public HealthDeclaration? HealthDeclaration { get; set; }
		public List<Plan> Plans { get; set; } = [];
        public Menu? Menu { get; set; }
    }
}
