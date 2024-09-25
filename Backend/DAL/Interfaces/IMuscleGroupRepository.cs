using DAL.Helpers;
using DAL.Models;

namespace DAL.Interfaces
{
	public interface IMuscleGroupRepository
	{
		Task<List<MuscleGroup>> GetAllAsync(QueryObject query);
		Task<MuscleGroup?> GetByNameAsync(string name);
		Task<MuscleGroup?> GetByIdAsync(int id);
		Task<MuscleGroup> CreateAsync(MuscleGroup muscleGroup);
		Task<MuscleGroup?> UpdateAsync(int id, MuscleGroup muscleGroup);
		Task<MuscleGroup?> DeleteAsync(MuscleGroup muscleGroup);
		Task<bool> MuscleGroupExist(string name);
	}
}
