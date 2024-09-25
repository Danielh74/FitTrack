using DAL.Data;
using DAL.Helpers;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class ExerciseRepository(AppDbContext context) : IExerciseRepository
	{
		public async Task<Exercise> CreateAsync(Exercise exerciseModel)
		{
			await context.Exercises.AddAsync(exerciseModel);
			await context.SaveChangesAsync();

			return exerciseModel;
		}

		public async Task<Exercise?> DeleteAsync(Exercise exerciseModel)
		{
			context.Exercises.Remove(exerciseModel);
			await context.SaveChangesAsync();

			return exerciseModel;
		}

		public async Task<List<Exercise>> GetAllAsync(QueryObject query)
		{
			var exercises = context.Exercises.Include(e => e.MuscleGroup).AsQueryable();

			if (!string.IsNullOrWhiteSpace(query.Name))
			{
				exercises = exercises.Where(e => e.Name.Contains(query.Name));
			}
			if (!string.IsNullOrWhiteSpace(query.SortBy))
			{
				if (query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
				{
					exercises = query.IsDecsending ? exercises.OrderByDescending(e => e.Name)
						: exercises.OrderBy(e => e.Name);
				}
			}

			return await exercises.ToListAsync();
		}

		public async Task<Exercise?> GetByIdAsync(int id)
		{
			var exercise = await context.Exercises
				.Include(e => e.MuscleGroup)
				.FirstOrDefaultAsync(e => e.Id == id);

			return exercise;
		}

		public async Task<Exercise?> GetByNameAsync(string name)
		{
			var exercise = await context.Exercises.FirstOrDefaultAsync(e => e.Name == name);
			if (exercise is null)
			{
				return null;
			}
			return exercise;
		}

		public async Task<bool> IsExists(string name)
		{
			var isExist = await context.Exercises.AnyAsync(e => e.Name == name);

			return isExist;
		}

		public async Task<Exercise?> UpdateAsync(int id, Exercise updatedExercise)
		{
			var currentExercise = await context.Exercises.FindAsync(id);
			if (currentExercise is null)
			{
				return null;
			}

			currentExercise.Name = updatedExercise.Name;
			currentExercise.MuscleGroupId = updatedExercise.MuscleGroupId;

			await context.SaveChangesAsync();

			return currentExercise;
		}
	}
}
