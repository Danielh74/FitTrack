using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public class MenuDetails
	{
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
		public int Order { get; set; }
		public int ProteinPoints { get; set; }
        public int CarbsPoints { get; set; }
        public int FatsPoints { get; set; }

        //Foreign key:
        public int MenuId { get; set; }

        //Navigation property:
        public Menu? Menu { get; set; }
    }
}