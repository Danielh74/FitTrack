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
				OrderInPlan = model.OrderInPlan,
				ExerciseName = model.Exercise.Name,
				Reps = model.Reps,
				Sets = model.Sets,
				CurrentWeight = model.CurrentWeight,
				PreviousWeight = model.PreviousWeight
			};
		}

		public static PlanDetails ToModelFromCreate(this CreatePlanDetailsDto dto)
		{
			return new PlanDetails
			{
				ExerciseId = dto.ExerciseId,
				PlanId = dto.PlanId,
				OrderInPlan = dto.OrderInPlan,
			};
		}

		public static PlanDetails ToModelFromUpdate(this UpdatePlanDetailsRequestDto dto)
		{
			return new PlanDetails
			{
				CurrentWeight = dto.CurrentWeight,
				PreviousWeight = dto.PreviousWeight,
			};
		}

		public static PlanDetails ToModelFromUpdate(this AdminUpdatePlanDetailsRequestDto dto)
		{
			return new PlanDetails
			{
				OrderInPlan = dto.OrderInPlan,
				Reps = dto.Reps,
				Sets = dto.Sets
			};
		}
	}
}
