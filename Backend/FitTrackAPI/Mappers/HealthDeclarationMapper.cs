using DAL.Models;
using FitTrackAPI.DTOs.Health_Declaration;
using FitTrackAPI.Helpers;

namespace FitTrackAPI.Mappers
{
	public static class HealthDeclarationMapper
	{
		public static HealthDeclarationDto ToDto(this HealthDeclaration healthDeclaration)
		{
			return new HealthDeclarationDto
			{
				Id = healthDeclaration.Id,
				HeartDisease = healthDeclaration.HeartDisease,
				ChestPainInRest = healthDeclaration.ChestPainInRest,
				ChestPainInDaily = healthDeclaration.ChestPainInDaily,
				ChestPainInActivity = healthDeclaration.ChestPainInActivity,
				Dizzy = healthDeclaration.Dizzy,
				LostConsciousness = healthDeclaration.LostConsciousness,
				AsthmaTreatment = healthDeclaration.AsthmaTreatment,
				ShortBreath = healthDeclaration.ShortBreath,
				FamilyDeathHeartDisease = healthDeclaration.FamilyDeathHeartDisease,
				FamilySuddenEarlyAgeDeath = healthDeclaration.FamilySuddenEarlyAgeDeath,
				TrainUnderSupervision = healthDeclaration.TrainUnderSupervision,
				ChronicIllness = healthDeclaration.ChronicIllness,
				IsPregnant = healthDeclaration.IsPregnant,
				AppUserId = healthDeclaration.AppUserId,
				UserName = Utils.UserFullName(healthDeclaration.AppUser.FirstName, healthDeclaration.AppUser.LastName)
			};
		}

		public static HealthDeclaration ToModelFromCreate(this CreateHealthDeclarationDto createDto, int userId)
		{
			return new HealthDeclaration
			{
				HeartDisease = createDto.HeartDisease,
				ChestPainInRest = createDto.ChestPainInRest,
				ChestPainInDaily = createDto.ChestPainInDaily,
				ChestPainInActivity = createDto.ChestPainInActivity,
				Dizzy = createDto.Dizzy,
				LostConsciousness = createDto.LostConsciousness,
				AsthmaTreatment = createDto.AsthmaTreatment,
				ShortBreath = createDto.ShortBreath,
				FamilyDeathHeartDisease = createDto.FamilyDeathHeartDisease,
				FamilySuddenEarlyAgeDeath = createDto.FamilySuddenEarlyAgeDeath,
				TrainUnderSupervision = createDto.TrainUnderSupervision,
				ChronicIllness = createDto.ChronicIllness,
				IsPregnant = createDto.IsPregnant,
				DateOfSignature = DateTime.UtcNow,
				AppUserId = userId
			};
		}
	}
}
