using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.MealDTOs
{
	public class CreateMealDto
	{
		[Required]
		[Range(1,int.MaxValue)]
        public int MenuId { get; set; }

		[Required]
		[MinLength(2)]
		public string Name { get; set; } = string.Empty;

		[Required]
		[Range(1, 20)]
		public int ProteinPoints { get; set; }

		[Required]
		[Range(1, 20)]
		public int CarbsPoints { get; set; }

		[Required]
		[Range(1, 20)]
		public int FatsPoints { get; set; }

		[Required]
		[Range(1, 20)]
		public int Order { get; set; }
	
	}
}
