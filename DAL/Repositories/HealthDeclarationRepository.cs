using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class HealthDeclarationRepository(AppDbContext context, UserManager<AppUser> userManager) : IHealthDeclarationRepository
	{
		public async Task<HealthDeclaration> CreateAsync(HealthDeclaration healthDec)
		{
			await context.HealthDeclarations.AddAsync(healthDec);
			await context.SaveChangesAsync();

			return healthDec;
		}

		public async Task<HealthDeclaration> DeleteAsync(HealthDeclaration healthDec)
		{
			context.HealthDeclarations.Remove(healthDec);
			await context.SaveChangesAsync();

			return healthDec;
		}

		public async Task<List<HealthDeclaration>> GetAllAsync()
		{
			var healthDecs = await context.HealthDeclarations
				.Include(h => h.AppUser).ToListAsync();
			if (healthDecs.Count == 0)
			{
				return null;
			}

			return healthDecs;
		}

		public async Task<HealthDeclaration?> GetByUserIdAsync(string userId)
		{
			var healthDec = await context.HealthDeclarations.FirstOrDefaultAsync(hd => hd.AppUserId == userId);
			if (healthDec is null)
			{
				return null;
			}

			return healthDec;
		}

		public async Task<HealthDeclaration> UpdateAsync(int id, HealthDeclaration healthDec)
		{
			var currentHealthDec = await context.HealthDeclarations.FindAsync(id);
			if (currentHealthDec is null)
			{
				return null;
			}

			currentHealthDec.HeartDisease = healthDec.HeartDisease;
			currentHealthDec.ChestPainInRest = healthDec.ChestPainInRest;
			currentHealthDec.ChestPainInDaily = healthDec.ChestPainInDaily;
			currentHealthDec.ChestPainInActivity = healthDec.ChestPainInActivity;
			currentHealthDec.Dizzy = healthDec.Dizzy;
			currentHealthDec.LostConsciousness = healthDec.LostConsciousness;
			currentHealthDec.AsthmaTreatment = healthDec.AsthmaTreatment;
			currentHealthDec.ShortBreath = healthDec.ShortBreath;
			currentHealthDec.FamilyDeathHeartDisease = healthDec.FamilyDeathHeartDisease;
			currentHealthDec.FamilySuddenEarlyAgeDeath = healthDec.FamilySuddenEarlyAgeDeath;
			currentHealthDec.TrainUnderSupervision = healthDec.TrainUnderSupervision;
			currentHealthDec.ChronicIllness = healthDec.ChronicIllness;
			currentHealthDec.IsPregnant = healthDec.IsPregnant;

			await context.SaveChangesAsync();

			return currentHealthDec;

		}
	}
}
