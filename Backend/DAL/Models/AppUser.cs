using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace DAL.Models
{
	public class AppUser : IdentityUser<int>
	{
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string Gender { get; set; } = string.Empty;
		public string City { get; set; } = string.Empty;
		public string Goal { get; set; } = string.Empty;
		public int Age { get; set; }
		public int Height { get; set; }
		public List<Weight> Weight { get; set; } = [];

		public double NeckCircumference { get; set; }
		public double PecsCircumference { get; set; }
		public double WaistCircumference { get; set; }
		public double AbdominalCircumference { get; set; }
		public double HipsCircumference { get; set; }
		public double ThighsCircumference { get; set; }
		public double ArmCircumference { get; set; }
		public double BodyFatPrecentage { get; set; }

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
