using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class MealsRepository(AppDbContext context) : IMenuDetailsRepository
	{
		public async Task<Meal> CreateAsync(Meal meal)
		{
			await context.Meals.AddAsync(meal);	
			await context.SaveChangesAsync();

			return meal;
		}

		public async Task<Meal?> DeleteAsync(Meal meal)
		{
			context.Meals.Remove(meal);
			await context.SaveChangesAsync();

			return meal;
		}

		public async Task<List<Meal>> GetAllAsync()
		{
			var mealsList = await context.Meals
				.Include(md => md.Menu)
				.ToListAsync();
			if (mealsList.Count == 0)
			{
				return null;
			}

			return mealsList;
		}

		public async Task<Meal?> GetByIdAsync(int id)
		{
			var meal = await context.Meals
				.Include(m => m.Menu)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (meal is null)
			{
				return null;
			}

			return meal;
		}

		public async Task<Meal?> UpdateAsync(int id, Meal meal)
		{
			var currentMeal = await context.Meals
				.Include(m => m.Menu)
				.FirstOrDefaultAsync(m => m.Id == id);
			if(currentMeal is null)
			{
				return null;
			}

			currentMeal.Name = meal.Name;
			currentMeal.ProteinPoints = meal.ProteinPoints;
			currentMeal.CarbsPoints = meal.CarbsPoints;
			currentMeal.FatsPoints = meal.FatsPoints;
			currentMeal.Order = meal.Order;

			await context.SaveChangesAsync();

			return currentMeal;
		}
	}
}
