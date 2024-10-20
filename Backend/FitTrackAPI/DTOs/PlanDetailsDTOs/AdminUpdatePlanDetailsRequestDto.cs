using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.PlanDetailsDTOs
{
	public class AdminUpdatePlanDetailsRequestDto
	{
		[Required]
		[Range(1, int.MaxValue)]
		public int OrderInPlan { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int Reps { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int Sets { get; set; }
	}
}
