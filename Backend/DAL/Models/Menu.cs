using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public class Menu
	{
		[Key]
        public int Id { get; set; }

        //Foreign Key:
        public string UserId { get; set; } = string.Empty;

        //Navigation properties:
        public AppUser? AppUser { get; set; }
        public List<Meal> Meals { get; set; } = [];

    }
}
