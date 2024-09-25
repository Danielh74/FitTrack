using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

	public class Exercise
	{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    //Foreign key:
    public int MuscleGroupId { get; set; }

    //Navigation property:
    public List<ExerciseDetails> ExerciseDetails { get; set; } = [];
	public MuscleGroup? MuscleGroup { get; set; }

}

