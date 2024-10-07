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
		public int Age { get; set; }
		public int Height { get; set; }
		public List<Weight> Weight { get; set; } = [];

		public double NeckCircumference { get; set; } = 0;
		public double PecsCircumference { get; set; } = 0;
		public double WaistCircumference { get; set; } = 0;
		public double AbdominalCircumference { get; set; } = 0;
		public double HipsCircumference { get; set; } = 0;
		public double ThighsCircumference { get; set; } = 0;
		public double ArmCircumference { get; set; } = 0;
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
