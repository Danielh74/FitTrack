using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public class Plan
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = string.Empty;

        //Foreign key:
        public string AppUserId { get; set; }

        //Navigation Property:
        public AppUser AppUser { get; set; }
		public List<PlanDetails> PlanDetails { get; set; } = [];
    }
}