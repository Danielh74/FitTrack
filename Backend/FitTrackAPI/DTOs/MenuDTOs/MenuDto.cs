using FitTrackAPI.DTOs.MealDTOs;

namespace FitTrackAPI.DTOs.MenuDTOs
{
	public class MenuDto
	{
        public int Id { get; set; }
		public string UserName { get; set; } = string.Empty;
		public List<MealDto> MenuDetails { get; set; } = [];
    }
}
