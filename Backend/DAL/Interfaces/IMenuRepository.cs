using DAL.Models;

namespace DAL.Interfaces
{
	public interface IMenuRepository
	{
		Task<List<Menu>> GetAllAsync();
		Task<Menu?> GetByIdAsync(int id);
		Task<Menu?> GetByUserIdAsync(int userId);
		Task<Menu> CreateAsync(Menu menu);
		Task<Menu?> DeleteAsync(Menu menu);


	}
}
