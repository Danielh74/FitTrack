using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public class MuscleGroup
	{
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        //Navigation Property:
        public List<Exercise> Exercises { get; set; } = [];
    }
}
