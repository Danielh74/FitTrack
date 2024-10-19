using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.Health_Declaration
{
	public class HealthDeclarationDto
	{
		public int Id { get; set; }

		public bool HeartDisease { get; set; }

		public bool ChestPainInRest { get; set; }

		public bool ChestPainInDaily { get; set; }

		public bool ChestPainInActivity { get; set; }

		public bool Dizzy { get; set; }

		public bool LostConsciousness { get; set; }

		public bool AsthmaTreatment { get; set; }

		public bool ShortBreath { get; set; }

		public bool FamilyDeathHeartDisease { get; set; }

		public bool FamilySuddenEarlyAgeDeath { get; set; }

		public bool TrainUnderSupervision { get; set; }

		public bool ChronicIllness { get; set; }

		public bool IsPregnant { get; set; }
		public int AppUserId { get; set; }
		public string UserName { get; set; } = string.Empty;
	}
}
