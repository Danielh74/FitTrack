using DAL.Models;
using FitTrackAPI.DTOs.MuscleGroup;

namespace FitTrackAPI.Mappers
{
	public static class MuscleGroupMapper
	{
		public static MuscleGroupDto ToDto(this MuscleGroup entity)
		{
			var exercisesNames = entity.Exercises.Select(x => x.Name).ToList();
			return new MuscleGroupDto
			{
				Id = entity.Id,
				Name = entity.Name,
				Exercises = exercisesNames
			};
		}

		public static MuscleGroup ToModelFromUpdate(this UpdateMuscleGroupRequestDto entity)
		{
			return new MuscleGroup 
			{
				Name = entity.Name
			};
		}

		public static MuscleGroup ToModelFromCreate(this CreateMuscleGroupDto entity)
		{
			return new MuscleGroup
			{
				Name = entity.Name
			};
		}
	}
}
