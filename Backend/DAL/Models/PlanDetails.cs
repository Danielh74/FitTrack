using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public class PlanDetails
	{
        public int PlanId { get; set; }
		public int ExerciseDetailsId { get; set; }
        public int OrederInPlan { get; set; }

        //Navigation properties:
        public ExerciseDetails? ExerciseDetails { get; set; }
		public Plan? Plan { get; set; }
	}
}
