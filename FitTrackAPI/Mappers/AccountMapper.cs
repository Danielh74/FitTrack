using DAL.Models;
using FitTrackAPI.DTOs.AccountDTOs;
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
				Id = model.Id,
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
				Plans = model.Plans.Select(p=> p.ToPlanDto()).ToList(),
			};
		}

		public static UserListDto ToListDto(this AppUser model)
		{
			return new UserListDto
			{
				Id = model.Id,
				FirstName = model.FirstName,
				LastName = model.LastName,
				Gender = model.Gender,
				City = model.City,
				Age = model.Age,
				AgreedToTerms = model.AgreedToTerms,
				HealthDeclarationId = model.HealthDeclarationId
			};
		}
	}
}
