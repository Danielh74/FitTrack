using DAL.Models;
using FitTrackAPI.DTOs.Account;
using System.Numerics;
using System.Reflection;

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

		public static UserDto ToDto(this AppUser model)
		{
			return new UserDto
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Gender = model.Gender,
				City = model.City,
				Age = model.Age,
				Height = model.Height,
				Weight = model.Weight,
				NeckCircumference = model.NeckCircumference,
				PecsCircumference = model.PecsCircumference,
				WaistCircumference = model.WaistCircumference,
				AbdominalCircumference = model.AbdominalCircumference,
				HipsCircumference = model.HipsCircumference,
				ThighsCircumference = model.ThighsCircumference,
				ArmCircumference = model.ArmCircumference,
				BodyFatPrecentage = model.BodyFatPrecentage,
				AgreedToTerms = model.AgreedToTerms,
				HealthDeclarationId = model.HealthDeclarationId,
				Plans = model.Plans
			};
		}
	}
}
