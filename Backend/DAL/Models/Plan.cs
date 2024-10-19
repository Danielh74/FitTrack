using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public class Plan
	{
		[Key]
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public bool IsCompleted { get; set; } = false;

		//Foreign key:
		public int AppUserId { get; set; }

        //Navigation Property:
        public AppUser? AppUser { get; set; }
		public List<PlanDetails> PlanDetails { get; set; } = [];
    }
}