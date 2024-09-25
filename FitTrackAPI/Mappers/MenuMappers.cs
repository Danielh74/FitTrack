using DAL.Models;
using FitTrackAPI.DTOs.MenuDTOs;
using FitTrackAPI.Helpers;

namespace FitTrackAPI.Mappers
{
	public static class MenuMappers
	{
		public static MenuListDto ToListDto(this Menu menu)
		{
			return new MenuListDto
			{
				Id = menu.Id,
				UserName = Utils.UserFullName(menu.AppUser.FirstName, menu.AppUser.LastName)
			};
		}

		public static MenuDto ToDto(this Menu menu)
		{
			return new MenuDto
			{
				Id = menu.Id,
				UserName = Utils.UserFullName(menu.AppUser.FirstName, menu.AppUser.LastName),
				MenuDetails = menu.MenuDetails.Select(md=> md.ToDto()).ToList()
			};
		}

		public static Menu ToModelFromCreate(this CreateMenuDto dto)
		{
			return new Menu
			{
				UserId = dto.UserId
			};
		}
	}
}
