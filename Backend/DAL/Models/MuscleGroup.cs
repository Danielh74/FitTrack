using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public class MuscleGroup
	{
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(20)]
        public string Name { get; set; } = string.Empty;

        //Navigation Property:
        public List<Exercise> Exercises { get; set; } = [];
    }
}
