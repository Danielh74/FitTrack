namespace FitTrackAPI.DTOs.MenuDetailsDTOs
{
	public class MenuDetailsDto
	{
        public int Order { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ProteinPoints { get; set; }
		public int CarbsPoints { get; set; }
		public int FatsPoints { get; set; }
	}
}
