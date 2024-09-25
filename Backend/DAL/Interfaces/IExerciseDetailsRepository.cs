using DAL.Helpers;
using DAL.Models;

namespace DAL.Interfaces
{
	public interface IExerciseDetailsRepository
	{
		Task<List<ExerciseDetails>> GetAllAsync(QueryObject query);
		Task<ExerciseDetails?> GetByIdAsync(int id);
		Task<ExerciseDetails> CreateAsync(ExerciseDetails exDetails);
		Task<ExerciseDetails?> UpdateAsync(int id, ExerciseDetails exDetails);
		Task<ExerciseDetails?> DeleteAsync(ExerciseDetails exDetails);

	}
}
