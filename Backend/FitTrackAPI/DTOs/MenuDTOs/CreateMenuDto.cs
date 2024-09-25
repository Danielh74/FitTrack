using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.MenuDTOs
{
	public class CreateMenuDto
	{
		[Required]
		public string UserId { get; set; } = string.Empty;
	}
}
