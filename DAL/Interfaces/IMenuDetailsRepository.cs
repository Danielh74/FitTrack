using DAL.Helpers;
using DAL.Models;

namespace DAL.Interfaces
{
	public interface IMenuDetailsRepository
	{
		Task<List<MenuDetails>> GetAllAsync();
		Task<MenuDetails?> GetByIdAsync(int id);
		Task<MenuDetails> CreateAsync(MenuDetails menuDetails);
		Task<MenuDetails?> UpdateAsync(int id, MenuDetails menuDetails);
		Task<MenuDetails?> DeleteAsync(MenuDetails menuDetails);
	}
}
