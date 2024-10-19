using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public class Menu
	{
		[Key]
        public int Id { get; set; }

        //Foreign Key:
        public int UserId { get; set; }

        //Navigation properties:
        public AppUser? AppUser { get; set; }
        public List<Meal> Meals { get; set; } = [];

    }
}
