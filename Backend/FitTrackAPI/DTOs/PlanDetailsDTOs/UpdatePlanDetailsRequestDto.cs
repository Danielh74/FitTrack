using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.PlanDetailsDTOs
{
	public class UpdatePlanDetailsRequestDto
	{
		[Range(1, double.MaxValue)]
		public double? CurrentWeight { get; set; } = null;

		[Range(1, double.MaxValue)]
		public double? PreviousWeight { get; set; } = null;
	}
}
