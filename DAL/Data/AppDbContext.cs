using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DAL.Data
{
	public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser>(options)
	{
		public DbSet<MuscleGroup> MuscleGroups { get; set; }
		public DbSet<Exercise> Exercises { get; set; }
		public DbSet<ExerciseDetails> ExercisesDetails { get; set; }
		public DbSet<Plan> Plans { get; set; }
		public DbSet<PlanDetails> PlansDetails { get; set; }
		public DbSet<HealthDeclaration> HealthDeclarations { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<PlanDetails>(x => x.HasKey(p => new { p.PlanId, p.ExerciseDetailsId }));

			builder.Entity<PlanDetails>().HasOne(pd => pd.Plan)
				.WithMany(p => p.PlanDetails)
				.HasForeignKey(pd => pd.PlanId);

			builder.Entity<PlanDetails>().HasOne(pd => pd.ExerciseDetails)
				.WithMany(e => e.PlanDetails)
				.HasForeignKey(pd => pd.ExerciseDetailsId);

			builder.Entity<AppUser>().HasMany(u => u.Plans)
				.WithOne(p => p.AppUser);

			builder.Entity<AppUser>().HasOne(u => u.HealthDeclaration)
				.WithOne(h => h.AppUser)
				.HasForeignKey<AppUser>(u => u.HealthDeclarationId);

			builder.Entity<Plan>().HasMany(p => p.PlanDetails)
				.WithOne(pd => pd.Plan)
				.HasForeignKey(pd => pd.PlanId);

			builder.Entity<ExerciseDetails>().HasMany(e => e.PlanDetails)
				.WithOne(pd => pd.ExerciseDetails)
				.HasForeignKey(pd => pd.ExerciseDetailsId);

			builder.Entity<MuscleGroup>().HasMany(m => m.Exercises)
				.WithOne(e => e.MuscleGroup)
				.HasForeignKey(e => e.MuscleGroupId);

			List<IdentityRole> roles = new List<IdentityRole>
			{
				new IdentityRole
				{
					Name = "Admin",
					NormalizedName = "ADMIN",
					ConcurrencyStamp = Guid.NewGuid().ToString()
				},
				new IdentityRole
				{
					Name = "User",
					NormalizedName = "USER",
					ConcurrencyStamp = Guid.NewGuid().ToString()
				},
			};

			builder.Entity<IdentityRole>().HasData(roles);

			List<MuscleGroup> muscleGroups = new List<MuscleGroup>
			{
				new MuscleGroup
				{
					Id = 1,
					Name = "Chest"
				},
				new MuscleGroup
				{
					Id = 2,
					Name = "Back"
				},
				new MuscleGroup
				{
					Id = 3,
					Name = "Biceps"
				},
				new MuscleGroup
				{
					Id = 4,
					Name = "Triceps"
				},
				new MuscleGroup
				{
					Id = 5,
					Name = "Abs"
				},
				new MuscleGroup
				{
					Id = 6,
					Name = "Shoulders"
				},
				new MuscleGroup
				{
					Id = 7,
					Name = "Legs"
				},
			};

			builder.Entity<MuscleGroup>().HasData(muscleGroups);
		}

	}
}
