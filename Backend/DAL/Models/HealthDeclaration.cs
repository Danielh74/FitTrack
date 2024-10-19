using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public class HealthDeclaration
	{
		[Key]
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

		public DateTime DateOfSignature { get; set; }

        //Foreign key:
        public int AppUserId { get; set; }

        //Navigation property:
        public AppUser? AppUser { get; set; }
    }
}