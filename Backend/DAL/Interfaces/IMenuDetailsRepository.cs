using DAL.Helpers;
using DAL.Models;

namespace DAL.Interfaces
{
	public interface IMenuDetailsRepository
	{
		Task<List<Meal>> GetAllAsync();
		Task<Meal?> GetByIdAsync(int id);
		Task<Meal> CreateAsync(Meal menuDetails);
		Task<Meal?> UpdateAsync(int id, Meal menuDetails);
		Task<Meal?> DeleteAsync(Meal menuDetails);
	}
}
