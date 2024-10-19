using DAL.Models;

namespace DAL.Interfaces
{
	public interface IHealthDeclarationRepository
	{
		Task<List<HealthDeclaration>> GetAllAsync();
		Task<HealthDeclaration?> GetByUserIdAsync(int userId);
		Task<HealthDeclaration?> GetByIdAsync(int id);
		Task<HealthDeclaration> CreateAsync(HealthDeclaration healthDec);
		Task<HealthDeclaration> UpdateAsync(int id, HealthDeclaration healthDec);
		Task<HealthDeclaration> DeleteAsync(HealthDeclaration healthDec);
	}
}
