using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.MuscleGroup
{
	public class UpdateMuscleGroupRequestDto
	{
        [Required]
		[MinLength(2), MaxLength(20)]
		public string Name { get; set; }
    }
}
