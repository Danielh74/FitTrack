using DAL.Data;
using DAL.Helpers;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;

namespace DAL.Repositories
{
	public class ExerciseDetailsRepository(AppDbContext context) : IExerciseDetailsRepository
	{
		public async Task<ExerciseDetails> CreateAsync(ExerciseDetails exDetails)
		{
			await context.ExercisesDetails.AddAsync(exDetails);
			await context.SaveChangesAsync();

			return exDetails;
		}

		public async Task<ExerciseDetails?> DeleteAsync(ExerciseDetails exDetails)
		{
			context.ExercisesDetails.Remove(exDetails);
			await context.SaveChangesAsync() ;

			return exDetails;
		}

		public async Task<List<ExerciseDetails>> GetAllAsync(QueryObject query)
		{
			var exDetailsQuery = context.ExercisesDetails
				.Include(ed => ed.Exercise).AsQueryable();

			if (!string.IsNullOrWhiteSpace(query.ExerciseName))
			{
				exDetailsQuery = exDetailsQuery.Where(e => e.Exercise.Name.Contains(query.ExerciseName));
			}
			if (!string.IsNullOrWhiteSpace(query.SortBy))
			{
				if (query.SortBy.Equals("ExerciseName", StringComparison.OrdinalIgnoreCase))
				{
					exDetailsQuery = query.IsDecsending ? exDetailsQuery.OrderByDescending(e => e.Exercise.Name)
						: exDetailsQuery.OrderBy(e => e.Exercise.Name);
				}
			}

			var exDetailsList = await exDetailsQuery.ToListAsync();
			if(exDetailsList.Count == 0)
			{
				return null;
			}

			return exDetailsList;
		}

		public async Task<ExerciseDetails?> GetByIdAsync(int id)
		{
			var exerciseDetails = await context.ExercisesDetails
				.Include(ed => ed.Exercise)
				.FirstOrDefaultAsync(ed => ed.Id == id);
			if (exerciseDetails is null)
			{
				return null;
			}
			return exerciseDetails;
		}

		public async Task<ExerciseDetails?> UpdateAsync(int id, ExerciseDetails updatedExDetails)
		{
			var currentExDetails = await context.ExercisesDetails
				.Include(e => e.Exercise)
				.FirstOrDefaultAsync(e => e.Id == id);
			if (currentExDetails is null)
			{
				return null;
			}

			currentExDetails.Sets = updatedExDetails.Sets;
			currentExDetails.Reps = updatedExDetails.Reps;
			currentExDetails.Description = updatedExDetails.Description;

			await context.SaveChangesAsync();

			return currentExDetails;

		}
	}
}
