using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.MenuDTOs
{
	public class CreateMenuDto
	{
		[Required]
		public int UserId { get; set; }
	}
}
