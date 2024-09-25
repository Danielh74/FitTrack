using DAL.Interfaces;
using DAL.Models;
using FitTrackAPI.DTOs.ExerciseDetails;

namespace FitTrackAPI.Mappers
{
	public static class ExerciseDetailsMapper
	{
		public static ExerciseDetailsDto ToDto(this ExerciseDetails model)
		{
			return new ExerciseDetailsDto
			{
				Id = model.Id,
				ExerciseName = model.Exercise.Name,
				Reps = model.Reps,
				Sets = model.Sets,
				Description = model.Description
			};
		}

		public static async Task<ExerciseDetails> ToModelFromCreate(this CreateExerciseDetailsDto exDetailsDto, IExerciseRepository repo)
		{
			var exercise = await repo.GetByNameAsync(exDetailsDto.ExerciseName);
			return new ExerciseDetails
			{
				ExerciseId = exercise.Id,
				Reps = exDetailsDto.Reps,
				Sets = exDetailsDto.Sets,
				Description = exDetailsDto.Description
			};
		}

		public static ExerciseDetails ToModelFromUpdate(this UpdateExerciseDetailsRequestDto exDetailsDto)
		{
			return new ExerciseDetails
			{
				Reps = exDetailsDto.Reps,
				Sets = exDetailsDto.Sets,
				Description = exDetailsDto.Description
			};
		}
	}
}
