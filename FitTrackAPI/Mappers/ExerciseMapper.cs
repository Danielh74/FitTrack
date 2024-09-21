using DAL.Interfaces;
using DAL.Models;
using FitTrackAPI.DTOs.Exercise;

namespace FitTrackAPI.Mappers
{
	public static class ExerciseMapper
	{
		public static ExerciseDto ToDto(this Exercise exerciseModel)
		{
			return new ExerciseDto
			{
				Id = exerciseModel.Id,
				Name = exerciseModel.Name,
				MuscleGroupName = exerciseModel.MuscleGroup.Name
			};
		}

		public static async Task<Exercise> ToModelFromCreate(this CreateExerciseDto exerciseDto, IMuscleGroupRepository repo)
		{
			var muscleGroup = await repo.GetByNameAsync(exerciseDto.MuscleGroupName);

			return new Exercise
			{
				Name = exerciseDto.Name,
				MuscleGroupId = muscleGroup.Id
			};
		}

		public static async Task<Exercise>  ToModelFromUpdate(this UpdateExerciseRequestDto exerciseDto, IMuscleGroupRepository repo)
		{
			var muscleGroup = await repo.GetByNameAsync(exerciseDto.MuscleGroupName);

			return new Exercise
			{
				Name = exerciseDto.Name,
				MuscleGroupId = muscleGroup.Id
			};
		}
	}
}
