using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class PlanRepository(AppDbContext context) : IPlanRepository
	{
		public async Task<Plan> CreateAsync(Plan plan)
		{
			await context.Plans.AddAsync(plan);
			await context.SaveChangesAsync();

			return plan;
		}

		public async Task<Plan?> DeleteAsync(Plan plan)
		{
			context.Plans.Remove(plan);
			await context.SaveChangesAsync();

			return plan;
		}

		public async Task<List<Plan?>> GetAllAsync()
		{
			var plans = await context.Plans.Include(p=> p.AppUser).ToListAsync();
			if(plans.Count == 0)
			{
				return null;
			}

			return plans;
		}

		public async Task<Plan?> GetByIdAsync(int id)
		{
			var plan = await context.Plans
				.Include(p=> p.AppUser)
				.Include(p=> p.PlanDetails)
					.ThenInclude(pd=> pd.Exercise)
				.FirstOrDefaultAsync(p=> p.Id == id);
			if(plan is null)
			{
				return null;
			}

			return plan;
		}

		public async Task<List<Plan?>> GetByUserIdAsync(int userId)
		{
			var plans = await context.Plans
				.Include(p => p.AppUser)
				.Include(p => p.PlanDetails)
					.ThenInclude(pd => pd.Exercise)
				.Where(p => p.AppUserId == userId)
				.ToListAsync();
			if(plans.Count == 0)
			{
				return null;
			}

			return plans;
		}

		public async Task<Plan?> UpdateAsync(int id, Plan updatedPlan)
		{
			var currentPlan = await context.Plans
				.Include(p=> p.AppUser)
				.Include (p=> p.PlanDetails)
					.ThenInclude (pd => pd.Exercise)
				.FirstOrDefaultAsync(p=> p.Id == id);
			if(currentPlan is null)
			{
				return null;
			}

			currentPlan.Name = updatedPlan.Name;
			currentPlan.IsCompleted = updatedPlan.IsCompleted;

			await context.SaveChangesAsync();

			return currentPlan;
		}
	}
}
