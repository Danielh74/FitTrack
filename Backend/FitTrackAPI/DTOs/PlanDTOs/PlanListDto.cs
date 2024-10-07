namespace FitTrackAPI.DTOs.PlanDTOs
{
	public class PlanListDto
	{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
		public bool IsCompleted { get; set; } = false;
	}
}
