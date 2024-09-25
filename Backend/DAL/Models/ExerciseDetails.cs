using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public class ExerciseDetails
	{
		[Key]
		public int Id { get; set; }

		public int Reps { get; set; }

		public int Sets { get; set; }

		public string Description { get; set; } = string.Empty;

		//Foreign key:
		public int ExerciseId { get; set; }

        //Navigation property:
        public Exercise? Exercise { get; set; }
		public List<PlanDetails> PlanDetails { get; set; } = [];
	}
}
