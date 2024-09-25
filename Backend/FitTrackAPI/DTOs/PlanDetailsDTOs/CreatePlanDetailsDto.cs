using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.PlanDetailsDTOs
{
	public class CreatePlanDetailsDto
	{
		[Required]
		[Range(1,int.MaxValue)]
        public int ExerciseDetailsId { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int PlanId { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int OrderInPlan { get; set; }
	}
}
