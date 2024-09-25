using DAL.Models;
using FitTrackAPI.DTOs.PlanDetails;
using FitTrackAPI.DTOs.PlanDetailsDTOs;

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

		public static PlanDetails ToModelFromCreate(this CreatePlanDetailsDto dto)
		{
			return new PlanDetails
			{
				ExerciseDetailsId = dto.ExerciseDetailsId,
				PlanId = dto.PlanId,
				OrederInPlan = dto.OrderInPlan,
			};
		}

		public static PlanDetails ToModelFromUpdate(this UpdatePlanDetailsRequestDto dto)
		{
			return new PlanDetails
			{
				OrederInPlan = dto.OrderInPlanId
			};
		}
	}
}
