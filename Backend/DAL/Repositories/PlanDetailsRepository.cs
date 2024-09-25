using DAL.Data;
using DAL.Helpers;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DAL.Repositories
{
	public class PlanDetailsRepository(AppDbContext context) : IPlanDetailsRepository
	{
		public async Task<PlanDetails> CreateAsync(PlanDetails planDetailsModel)
		{
			await context.PlansDetails.AddAsync(planDetailsModel);
			await context.SaveChangesAsync();

			return planDetailsModel;
		}

		public async Task<PlanDetails?> DeleteAsync(PlanDetails planDetailsModel)
		{
			context.PlansDetails.Remove(planDetailsModel);
			await context.SaveChangesAsync();

			return planDetailsModel;
		}

		public async Task<List<PlanDetails?>> GetAllAsync()
		{
			var planDetailsList = await context.PlansDetails
				.Include(pd => pd.ExerciseDetails)
					.ThenInclude(ed => ed.Exercise)
				.ToListAsync();
			if (planDetailsList.Count == 0)
			{
				return null;
			}

			return planDetailsList;
		}

		public async Task<PlanDetails?> GetByKeyAsync(int planId, int exDetailsId)
		{
			if (planId <= 0 || exDetailsId <= 0)
			{
				return null;
			}

			var planDetails = await context.PlansDetails
				.Include(pd => pd.ExerciseDetails)
					.ThenInclude(ed => ed.Exercise)
				.FirstOrDefaultAsync(pd => pd.PlanId == planId && pd.ExerciseDetailsId == exDetailsId);

			if (planDetails is null)
			{
				return null;
			}

			return planDetails;
		}

		public async Task<PlanDetails?> GetByPlanIdAsync(int planId)
		{
			var planDetails = await context.PlansDetails
				.Include(pd => pd.ExerciseDetails)
					.ThenInclude(ed => ed.Exercise)
				.FirstOrDefaultAsync(pd => pd.PlanId == planId);

			if (planDetails is null)
			{
				return null;
			}

			return planDetails;
		}

		public async Task<PlanDetails?> UpdateAsync(int planId,int exDetailsId, PlanDetails planDetailsModel)
		{
			var currentPlanDetails = await context.PlansDetails
				.Include(pd => pd.ExerciseDetails)
					.ThenInclude(ed => ed.Exercise)
				.FirstOrDefaultAsync(pd => pd.PlanId == planId && pd.ExerciseDetailsId == exDetailsId);
			if (currentPlanDetails is null)
			{
				return null;
			}

			currentPlanDetails.OrederInPlan = planDetailsModel.OrederInPlan;

			await context.SaveChangesAsync();

			return currentPlanDetails;
		}
	}
}
