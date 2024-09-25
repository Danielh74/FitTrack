using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.PlanDetailsDTOs
{
	public class UpdatePlanDetailsRequestDto
	{
		[Required]
		[Range(1, int.MaxValue)]
		public int OrderInPlanId { get; set; }
	}
}
