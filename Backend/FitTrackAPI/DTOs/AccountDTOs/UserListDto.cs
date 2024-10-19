namespace FitTrackAPI.DTOs.AccountDTOs
{
	public class UserListDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string Gender { get; set; } = string.Empty;
		public string City { get; set; } = string.Empty;
		public int Age { get; set; }
		public bool AgreedToTerms { get; set; } = false;
		public int? HealthDeclarationId { get; set; }
	}
}
