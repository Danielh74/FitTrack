using DAL.Models;
using FitTrackAPI.DTOs.MenuDetailsDTOs;

namespace FitTrackAPI.Mappers
{
	public static class MenuDetailsMappers
	{
		public static MenuDetailsDto ToDto(this Meal model)
		{
			return new MenuDetailsDto
			{
				Order = model.Order,
				Name = model.Name,
				ProteinPoints = model.ProteinPoints,
				CarbsPoints = model.CarbsPoints,
				FatsPoints = model.FatsPoints
			};
		}

		public static MenuDetailsListDto ToListDto(this Meal model)
		{
			return new MenuDetailsListDto
			{
				Id = model.Id,
				MenuId = model.MenuId,
				Name = model.Name
			};
		}

		public static Meal ToModelFromUpdate(this UpdateMenuDetailsRequestDto dto)
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

		public static Meal ToModelFromCreate(this CreateMenuDetailsDto dto)
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
