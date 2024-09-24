using DAL.Models;

namespace FitTrackAPI.DTOs.PlanDetails
{
	public class PlanDetailsDto
	{
        public int OrderInPlan { get; set; }
		public string ExerciseName { get; set;} = string.Empty;
		public int Reps { get; set; }
		public int Sets { get; set; }
		public string Description { get; set; }  =string.Empty;
	}
}
