using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class MenuDetailsRepository(AppDbContext context) : IMenuDetailsRepository
	{
		public async Task<MenuDetails> CreateAsync(MenuDetails menuDetails)
		{
			await context.MenuDetails.AddAsync(menuDetails);	
			await context.SaveChangesAsync();

			return menuDetails;
		}

		public async Task<MenuDetails?> DeleteAsync(MenuDetails menuDetails)
		{
			context.MenuDetails.Remove(menuDetails);
			await context.SaveChangesAsync();

			return menuDetails;
		}

		public async Task<List<MenuDetails>> GetAllAsync()
		{
			var menuDetailsList = await context.MenuDetails
				.Include(md => md.Menu)
				.ToListAsync();
			if (menuDetailsList.Count == 0)
			{
				return null;
			}

			return menuDetailsList;
		}

		public async Task<MenuDetails?> GetByIdAsync(int id)
		{
			var menuDetails = await context.MenuDetails
				.Include(md => md.Menu)
				.FirstOrDefaultAsync(md => md.Id == id);
			if (menuDetails is null)
			{
				return null;
			}

			return menuDetails;
		}

		public async Task<MenuDetails?> UpdateAsync(int id, MenuDetails menuDetails)
		{
			var currentMenuDetails = await context.MenuDetails
				.Include(md => md.Menu)
				.FirstOrDefaultAsync(md => md.Id == id);
			if(currentMenuDetails is null)
			{
				return null;
			}

			currentMenuDetails.Name = menuDetails.Name;
			currentMenuDetails.ProteinPoints = menuDetails.ProteinPoints;
			currentMenuDetails.CarbsPoints = menuDetails.CarbsPoints;
			currentMenuDetails.FatsPoints = menuDetails.FatsPoints;
			currentMenuDetails.Order = menuDetails.Order;

			await context.SaveChangesAsync();

			return currentMenuDetails;
		}
	}
}
