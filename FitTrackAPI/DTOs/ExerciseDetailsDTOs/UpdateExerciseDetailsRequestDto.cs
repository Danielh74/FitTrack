using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.ExerciseDetails
{
	public class UpdateExerciseDetailsRequestDto
	{
		[Required]
		[Range(1, int.MaxValue)]
		public int Reps { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int Sets { get; set; }

		[MinLength(2), MaxLength(200)]
		public string Description { get; set; } = string.Empty;
	}
}
