namespace FitTrackAPI.DTOs.MealDTOs
{
	public class MealsListDto
	{
        public int Id { get; set; }
		public int MenuId { get; set; }
		public string Name { get; set; } = string.Empty;
	}
}
