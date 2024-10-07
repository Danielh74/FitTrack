using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.PlanDTOs
{
	public class UpdatePlanRequestDto
	{
		[Required]
		[MinLength(1)]
		public string Name { get; set; } = string.Empty;

		[Required]
		public bool IsCompleted { get; set; } = false;
	}
}
