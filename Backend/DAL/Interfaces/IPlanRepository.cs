using DAL.Models;

namespace DAL.Interfaces
{
	public interface IPlanRepository
	{
		Task<List<Plan?>> GetAllAsync();
		Task<Plan?> GetByIdAsync(int id);
		Task<List<Plan?>> GetByUserIdAsync(int userId);
		Task<Plan> CreateAsync(Plan plan);
		Task<Plan?> UpdateAsync(int id, Plan plan);
		Task<Plan?> DeleteAsync(Plan plan);

	}
}
