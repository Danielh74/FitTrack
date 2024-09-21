using DAL.Models;
using FitTrackAPI.DTOs.Account;

namespace FitTrackAPI.Mappers
{
	public static class AccountMapper
	{
		public static AppUser ToUser(this RegisterDto dto)
		{
			return new AppUser 
			{
				FirstName = dto.FirstName,
				LastName = dto.LastName,
				Email = dto.Email,
				Age = dto.Age,
				Gender = dto.Gender,
				UserName = dto.Email
			};
		}
	}
}
