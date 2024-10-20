using DAL.Models;

namespace FitTrackAPI.DTOs.PlanDetails
{
	public class PlanDetailsDto
	{
        public int OrderInPlan { get; set; }
		public string ExerciseName { get; set;} = string.Empty;
		public int Reps { get; set; }
		public int Sets { get; set; }
		public double? CurrentWeight { get; set; } = null;
		public double? PreviousWeight { get; set; } = null;
	}
}
