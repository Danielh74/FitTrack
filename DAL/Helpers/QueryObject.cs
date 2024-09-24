namespace DAL.Helpers
{
	public class QueryObject
	{
		public string? Name { get; set; } = null;
		public string? ExerciseName { get; set; } = null;
		public string? SortBy { get; set; } = null;
		public bool IsDecsending { get; set; } = false;
		public int PlanId { get; set; }
		public int ExDetailsId { get; set; }
	}
}
