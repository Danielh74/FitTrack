using DAL.Helpers;
using DAL.Models;

namespace DAL.Interfaces
{
	public interface IPlanDetailsRepository
	{
		Task<List<PlanDetails?>> GetAllAsync();
		Task<PlanDetails?> GetByIdAsync(int id);
		Task<PlanDetails?> GetByPlanIdAsync(int planId);
		Task<PlanDetails> CreateAsync(PlanDetails planDetailsModel);
		Task<PlanDetails?> UpdateAsync(int id, PlanDetails planDetailsModel);
		Task<PlanDetails?> DeleteAsync(PlanDetails planDetailsModel);
	}
}
