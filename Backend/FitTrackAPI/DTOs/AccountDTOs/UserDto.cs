using DAL.Models;
using FitTrackAPI.DTOs.Health_Declaration;
using FitTrackAPI.DTOs.PlanDTOs;
using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.AccountDTOs
{
	public class UserDto
	{
		public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;

		public string LastName { get; set; } = string.Empty;

		public string Gender { get; set; } = string.Empty;

		public string City { get; set; } = string.Empty;

		public int Age { get; set; }

		public int Height { get; set; }

		public double Weight { get; set; }

		public string Goal { get; set; } = string.Empty;

		public double NeckCircumference { get; set; } = 0;

		public double PecsCircumference { get; set; } = 0;

		public double WaistCircumference { get; set; } = 0;

		public double AbdominalCircumference { get; set; } = 0;

		public double HipsCircumference { get; set; } = 0;

		public double ThighsCircumference { get; set; } = 0;

		public double ArmCircumference { get; set; } = 0;

		public double BodyFatPrecentage { get; set; } = 0;

		public bool AgreedToTerms { get; set; } = false;
		public int? HealthDeclarationId { get; set; }
		public List<PlanDto> Plans { get; set; } = [];
		public Menu? Menu { get; set; }
	}
}
