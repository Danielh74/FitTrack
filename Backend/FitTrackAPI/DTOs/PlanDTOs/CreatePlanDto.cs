using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.PlanDTOs
{
	public class CreatePlanDto
	{
		[Required]
		public int UserId { get; set; }

		[Required]
		[MinLength(1)]
		public string Name { get; set; } = string.Empty;
    }
}
