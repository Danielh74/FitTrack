using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.PlanDTOs
{
	public class CreatePlanDto
	{
		[Required]
		public string UserId { get; set; } = string.Empty;

		[Required]
		[MinLength(1)]
		public string Name { get; set; } = string.Empty;
    }
}
