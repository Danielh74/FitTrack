using DAL.Models;
using FitTrackAPI.DTOs.Health_Declaration;
using FitTrackAPI.DTOs.PlanDTOs;
using FitTrackAPI.DTOs.WeightDTOs;
using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.AccountDTOs
{
	public class UserDto
	{
		public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;

		public string LastName { get; set; } = string.Empty;

		public string Gender { get; set; } = string.Empty;

		public string City { get; set; } = string.Empty;

		public int Age { get; set; }

		public int Height { get; set; }

		public List<WeightDto> Weight { get; set; } = [];

		public string Goal { get; set; } = string.Empty;

		public double NeckCircumference { get; set; }

		public double PecsCircumference { get; set; }

		public double WaistCircumference { get; set; }

		public double AbdominalCircumference { get; set; }

		public double HipsCircumference { get; set; }

		public double ThighsCircumference { get; set; }

		public double ArmCircumference { get; set; }

		public double BodyFatPrecentage { get; set; }

		public bool AgreedToTerms { get; set; } = false;
		public int? HealthDeclarationId { get; set; }
		public List<PlanDto> Plans { get; set; } = [];
		public Menu? Menu { get; set; }
	}
}
