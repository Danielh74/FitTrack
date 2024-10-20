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
				.Include(pd => pd.Exercise)
				.ToListAsync();
			if (planDetailsList.Count == 0)
			{
				return null;
			}

			return planDetailsList;
		}

		public async Task<PlanDetails?> GetByIdAsync(int id)
		{
			var planDetails = await context.PlansDetails
				.Include(pd => pd.Exercise)
				.FirstOrDefaultAsync(pd => pd.Id == id);

			if (planDetails is null)
			{
				return null;
			}

			return planDetails;
		}

		public async Task<PlanDetails?> GetByPlanIdAsync(int planId)
		{
			var planDetails = await context.PlansDetails
				.Include(pd => pd.Exercise)
				.FirstOrDefaultAsync(pd => pd.PlanId == planId);

			if (planDetails is null)
			{
				return null;
			}

			return planDetails;
		}

		public async Task<PlanDetails?> UpdateAsync(int id, PlanDetails planDetailsModel)
		{
			var currentPlanDetails = await context.PlansDetails
				.Include(pd => pd.Exercise)
				.FirstOrDefaultAsync(pd => pd.Id == id);
			if (currentPlanDetails is null)
			{
				return null;
			}
			currentPlanDetails.ExerciseId = planDetailsModel.ExerciseId;
			currentPlanDetails.Reps = planDetailsModel.Reps;
			currentPlanDetails.Sets = planDetailsModel.Sets;
			currentPlanDetails.OrderInPlan = planDetailsModel.OrderInPlan;
			currentPlanDetails.PreviousWeight = planDetailsModel.PreviousWeight;
			currentPlanDetails.CurrentWeight = planDetailsModel.CurrentWeight;

			await context.SaveChangesAsync();

			return currentPlanDetails;
		}
	}
}
