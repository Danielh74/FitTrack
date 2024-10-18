using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public class Meal
	{
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
		public int Order { get; set; }
		public int ProteinPoints { get; set; }
        public int CarbsPoints { get; set; }
        public int FatsPoints { get; set; }
        public bool IsCompleted { get; set; } = false;

        //Foreign key:
        public int MenuId { get; set; }

        //Navigation property:
        public Menu? Menu { get; set; }
    }
}