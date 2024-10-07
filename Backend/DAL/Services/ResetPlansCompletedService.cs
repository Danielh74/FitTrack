
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Services
{
	public class ResetPlansCompletedService(IServiceScopeFactory scopeFactory) : BackgroundService
	{
		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested) 
			{
				var now = DateTime.UtcNow;
				var nextSunday = DateTime.Today.AddDays(((int)DayOfWeek.Sunday - (int)now.DayOfWeek + 7)%7).AddHours(0);
				var delay = nextSunday - now;

				await Task.Delay(delay, stoppingToken);

				using( var scope = scopeFactory.CreateScope())
				{
					var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
					var plans = await dbContext.Plans.ToListAsync();
					plans.ForEach(plan => { plan.IsCompleted = false; });

					await dbContext.SaveChangesAsync();
				}
			}

		}
	}
}
