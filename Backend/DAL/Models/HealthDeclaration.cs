using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public class HealthDeclaration
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public bool HeartDisease { get; set; }

		[Required]
		public bool ChestPainInRest { get; set; }

		[Required]
		public bool ChestPainInDaily { get; set; }

		[Required]
		public bool ChestPainInActivity { get; set; }

		[Required]
		public bool Dizzy { get; set; }

		[Required]
		public bool LostConsciousness { get; set; }

		[Required]
		public bool AsthmaTreatment { get; set; }

		[Required]
		public bool ShortBreath { get; set; }

		[Required]
		public bool FamilyDeathHeartDisease { get; set; }

		[Required]
		public bool FamilySuddenEarlyAgeDeath { get; set; }

		[Required]
		public bool TrainUnderSupervision { get; set; }

		[Required]
		public bool ChronicIllness { get; set; }

		[Required]
		public bool IsPregnant { get; set; }

		public DateTime DateOfSignature { get; set; }

        //Foreign key:
        public string AppUserId { get; set; } = string.Empty;

        //Navigation property:
        public AppUser? AppUser { get; set; }
    }
}