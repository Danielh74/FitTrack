using DAL.Models;
using FitTrackAPI.DTOs.MealDTOs;

namespace FitTrackAPI.Mappers
{
	public static class MealMappers
	{
		public static MealDto ToDto(this Meal model)
		{
			return new MealDto
			{
				Order = model.Order,
				Name = model.Name,
				ProteinPoints = model.ProteinPoints,
				CarbsPoints = model.CarbsPoints,
				FatsPoints = model.FatsPoints
			};
		}

		public static MealsListDto ToListDto(this Meal model)
		{
			return new MealsListDto
			{
				Id = model.Id,
				MenuId = model.MenuId,
				Name = model.Name
			};
		}

		public static Meal ToModelFromUpdate(this UpdateMealRequestDto dto)
		{
			return new Meal
			{
				Order = dto.Order,
				Name = dto.Name,
				ProteinPoints = dto.ProteinPoints,
				CarbsPoints = dto.CarbsPoints,
				FatsPoints = dto.FatsPoints
			};
		}

		public static Meal ToModelFromCreate(this CreateMealDto dto)
		{
			return new Meal
			{
				MenuId = dto.MenuId,
				Order = dto.Order,
				Name = dto.Name,
				ProteinPoints = dto.ProteinPoints,
				CarbsPoints = dto.CarbsPoints,
				FatsPoints = dto.FatsPoints
			};
		}
	}
}
