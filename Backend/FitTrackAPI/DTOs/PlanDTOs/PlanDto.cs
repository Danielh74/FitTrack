using DAL.Models;
using FitTrackAPI.DTOs.PlanDetails;

namespace FitTrackAPI.DTOs.PlanDTOs
{
	public class PlanDto
	{
		public int Id { get; set; }
		public string UserName { get; set; } = string.Empty;
		public bool IsCompleted { get; set; } = false;
		public string Name { get; set; } = string.Empty;
		public List<PlanDetailsDto> PlanDetails { get; set; } = [];
	}
}
