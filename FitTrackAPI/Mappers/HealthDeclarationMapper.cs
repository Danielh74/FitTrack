using DAL.Models;
using FitTrackAPI.DTOs.HealthDeclaration;

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
				UserName = healthDeclaration.AppUser.UserName
			};
		}
	}
}
