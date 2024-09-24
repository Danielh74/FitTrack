using DAL.Models;
using FitTrackAPI.DTOs.PlanDetails;

namespace FitTrackAPI.Mappers
{
	public static class PlanDetailsMapper
	{
		public static PlanDetailsDto ToDto(this PlanDetails model)
		{
			return new PlanDetailsDto
			{
				OrderInPlan = model.OrederInPlan,
				ExerciseName = model.ExerciseDetails.Exercise.Name,
				Reps = model.ExerciseDetails.Reps,
				Sets = model.ExerciseDetails.Sets,
				Description = model.ExerciseDetails.Description,	
			};
		}
	}
}
