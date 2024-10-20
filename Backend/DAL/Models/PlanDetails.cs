using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public class PlanDetails
	{
		[Key]
		public int Id { get; set; }
		public int Reps { get; set; }
		public int Sets { get; set; }
		public int OrderInPlan { get; set; }
		public double? CurrentWeight { get; set; } = null;
		public double? PreviousWeight { get; set; } = null;

		//Foreign Keys:
		public int PlanId { get; set; }
        public int ExerciseId { get; set; }

        //Navigation properties:
        public Exercise? Exercise { get; set; }
		public Plan? Plan { get; set; }
	}
}
