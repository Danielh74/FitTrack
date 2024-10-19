using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class HealthDeclarationRepository(AppDbContext context) : IHealthDeclarationRepository
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

		public async Task<HealthDeclaration?> GetByIdAsync(int id)
		{
			var healthDec = await context.HealthDeclarations.FindAsync(id);
			if (healthDec is null)
			{
				return null;
			}

			return healthDec;
		}

		public async Task<HealthDeclaration?> GetByUserIdAsync(int userId)
		{
			var healthDec = await context.HealthDeclarations.FirstOrDefaultAsync(hd => hd.AppUserId == userId);
			if (healthDec is null)
			{
				return null;
			}

			return healthDec;
		}

		public async Task<HealthDeclaration> UpdateAsync(int id, HealthDeclaration updatedHealthDec)
		{
			var currentHealthDec = await context.HealthDeclarations.FindAsync(id);
			if (currentHealthDec is null)
			{
				return null;
			}

			currentHealthDec.HeartDisease = updatedHealthDec.HeartDisease;
			currentHealthDec.ChestPainInRest = updatedHealthDec.ChestPainInRest;
			currentHealthDec.ChestPainInDaily = updatedHealthDec.ChestPainInDaily;
			currentHealthDec.ChestPainInActivity = updatedHealthDec.ChestPainInActivity;
			currentHealthDec.Dizzy = updatedHealthDec.Dizzy;
			currentHealthDec.LostConsciousness = updatedHealthDec.LostConsciousness;
			currentHealthDec.AsthmaTreatment = updatedHealthDec.AsthmaTreatment;
			currentHealthDec.ShortBreath = updatedHealthDec.ShortBreath;
			currentHealthDec.FamilyDeathHeartDisease = updatedHealthDec.FamilyDeathHeartDisease;
			currentHealthDec.FamilySuddenEarlyAgeDeath = updatedHealthDec.FamilySuddenEarlyAgeDeath;
			currentHealthDec.TrainUnderSupervision = updatedHealthDec.TrainUnderSupervision;
			currentHealthDec.ChronicIllness = updatedHealthDec.ChronicIllness;
			currentHealthDec.IsPregnant = updatedHealthDec.IsPregnant;

			await context.SaveChangesAsync();

			return currentHealthDec;

		}
	}
}
