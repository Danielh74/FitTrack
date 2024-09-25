using FitTrackAPI.DTOs.MenuDetailsDTOs;

namespace FitTrackAPI.DTOs.MenuDTOs
{
	public class MenuDto
	{
        public int Id { get; set; }
		public string UserName { get; set; } = string.Empty;
		public List<MenuDetailsDto> MenuDetails { get; set; } = [];
    }
}
