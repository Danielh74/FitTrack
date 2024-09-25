using DAL.Data;
using DAL.Helpers;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class MuscleGroupRepository(AppDbContext context) : IMuscleGroupRepository
	{
		public async Task<MuscleGroup> CreateAsync(MuscleGroup muscleGroup)
		{
			await context.AddAsync(muscleGroup);
			await context.SaveChangesAsync();

			return muscleGroup;
		}

		public async Task<MuscleGroup?> DeleteAsync(MuscleGroup muscleGroup)
		{
			context.MuscleGroups.Remove(muscleGroup);
			await context.SaveChangesAsync();

			return muscleGroup;
		}

		public async Task<List<MuscleGroup>> GetAllAsync(QueryObject query)
		{
			var muscleGroups = context.MuscleGroups.Include(m => m.Exercises).AsQueryable();

			if (!string.IsNullOrWhiteSpace(query.Name))
			{
				muscleGroups = muscleGroups.Where(e => e.Name.Contains(query.Name));
			}
			if (!string.IsNullOrWhiteSpace(query.SortBy))
			{
				if (query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
				{
					muscleGroups = query.IsDecsending ? muscleGroups.OrderByDescending(e => e.Name)
						: muscleGroups.OrderBy(e => e.Name);
				}
			}

			return await muscleGroups.ToListAsync();
		}

		public async Task<MuscleGroup?> GetByIdAsync(int id)
		{
			var muscleGroup = await context.MuscleGroups
				.Include(m => m.Exercises)
				.FirstOrDefaultAsync(m => m.Id == id);

			return muscleGroup;
		}

		public async Task<MuscleGroup?> GetByNameAsync(string name)
		{
			var muscleGroup = await context.MuscleGroups.FirstOrDefaultAsync(m => m.Name == name);

			return muscleGroup;
		}

		public async Task<bool> MuscleGroupExist(string name)
		{
			return await context.MuscleGroups.AnyAsync(m => m.Name == name);
		}

		public async Task<MuscleGroup?> UpdateAsync(int id, MuscleGroup updatedMuscleGroup)
		{
			var currentMuscleGroup = await context.MuscleGroups.FindAsync(id);
			if (currentMuscleGroup is null)
			{
				return null;
			}

			if(await MuscleGroupExist(updatedMuscleGroup.Name))
			{
				return null;
			}

			currentMuscleGroup.Name = updatedMuscleGroup.Name;

			await context.SaveChangesAsync();

			return currentMuscleGroup;
		}
	}
}
