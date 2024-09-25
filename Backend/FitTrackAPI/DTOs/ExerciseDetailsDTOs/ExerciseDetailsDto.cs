namespace FitTrackAPI.DTOs.ExerciseDetails
{
	public class ExerciseDetailsDto
	{
        public int Id { get; set; }
		public string ExerciseName { get; set; } = string.Empty;
		public int Reps { get; set; }
		public int Sets { get; set; }
		public string Description { get; set; } = string.Empty;
	}
}
