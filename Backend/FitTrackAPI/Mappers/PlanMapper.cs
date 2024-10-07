using DAL.Models;
using FitTrackAPI.DTOs.PlanDTOs;
using FitTrackAPI.Helpers;

namespace FitTrackAPI.Mappers
{
	public static class PlanMapper
	{
		public static Plan ToModelFromUpdate(this UpdatePlanRequestDto dto)
		{
			return new Plan
			{
				Name = dto.Name,
				IsCompleted = dto.IsCompleted,
			};
		}

		public static PlanListDto ToListDto(this Plan model)
		{
			return new PlanListDto
			{
				Id = model.Id,
				Name = model.Name,
				UserName = Utils.UserFullName(model.AppUser!.FirstName, model.AppUser.LastName),
				IsCompleted = model.IsCompleted,
			};
		}

		public static PlanDto ToPlanDto(this Plan model)
		{
			return new PlanDto
			{
				Id = model.Id,
				UserName = Utils.UserFullName(model.AppUser!.FirstName, model.AppUser.LastName),
				Name = model.Name,
				PlanDetails = model.PlanDetails.Select(pd => pd.ToDto()).ToList(),
				IsCompleted = model.IsCompleted,
			};
		}

		public static Plan ToModelFromCreate(this CreatePlanDto dto)
		{
			return new Plan
			{
				Name = dto.Name,
				AppUserId = dto.UserId
			};
		}
	}
}
