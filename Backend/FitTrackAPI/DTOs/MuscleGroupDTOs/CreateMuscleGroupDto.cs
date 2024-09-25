using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.MuscleGroup
{
	public class CreateMuscleGroupDto
	{
        [Required]
        [MinLength(2), MaxLength(20)]
        public string Name { get; set; } = string.Empty;
    }
}
