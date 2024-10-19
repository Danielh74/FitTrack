using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class MenuRepository(AppDbContext context) : IMenuRepository
	{
		public async Task<Menu> CreateAsync(Menu menu)
		{
			await context.Menus.AddAsync(menu);
			await context.SaveChangesAsync();

			return menu;
		}

		public async Task<Menu?> DeleteAsync(Menu menu)
		{
			context.Menus.Remove(menu);
			await context.SaveChangesAsync();

			return menu;
		}

		public async Task<List<Menu>> GetAllAsync()
		{
			var menus = await context.Menus
				.Include(m=> m.AppUser)
				.ToListAsync();
			if(menus.Count == 0)
			{
				return null;
			}

			return menus;
		}

		public async Task<Menu?> GetByIdAsync(int id)
		{
			var menu = await context.Menus
				.Include(m=> m.AppUser)
				.Include(m=> m.Meals)
				.FirstOrDefaultAsync(m => m.Id == id);

			if(menu is null)
			{
				return null;
			}

			return menu;
		}

		public async Task<Menu?> GetByUserIdAsync(int userId)
		{
			var menu = await context.Menus
				.Include(m => m.AppUser)
				.Include(m => m.Meals)
				.FirstOrDefaultAsync(m => m.UserId == userId);

			if (menu is null)
			{
				return null;
			}

			return menu;
		}
	}
}
