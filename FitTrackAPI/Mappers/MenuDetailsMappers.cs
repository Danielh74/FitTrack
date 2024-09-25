using DAL.Models;
using FitTrackAPI.DTOs.MenuDetailsDTOs;

namespace FitTrackAPI.Mappers
{
	public static class MenuDetailsMappers
	{
		public static MenuDetailsDto ToDto(this MenuDetails model)
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

		public static MenuDetailsListDto ToListDto(this MenuDetails model)
		{
			return new MenuDetailsListDto
			{
				Id = model.Id,
				MenuId = model.MenuId,
				Name = model.Name
			};
		}

		public static MenuDetails ToModelFromUpdate(this UpdateMenuDetailsRequestDto dto)
		{
			return new MenuDetails
			{
				Order = dto.Order,
				Name = dto.Name,
				ProteinPoints = dto.ProteinPoints,
				CarbsPoints = dto.CarbsPoints,
				FatsPoints = dto.FatsPoints
			};
		}

		public static MenuDetails ToModelFromCreate(this CreateMenuDetailsDto dto)
		{
			return new MenuDetails
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
