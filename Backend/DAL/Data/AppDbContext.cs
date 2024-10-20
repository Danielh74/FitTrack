using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DAL.Data
{
	public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser, IdentityRole<int>, int>(options)
	{
		public DbSet<MuscleGroup> MuscleGroups { get; set; }
		public DbSet<Exercise> Exercises { get; set; }
		public DbSet<Plan> Plans { get; set; }
		public DbSet<PlanDetails> PlansDetails { get; set; }
		public DbSet<HealthDeclaration> HealthDeclarations { get; set; }
		public DbSet<Menu> Menus { get; set; }
		public DbSet<Meal> Meals { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<AppUser>().HasMany(u => u.Plans)
				.WithOne(p => p.AppUser);

			builder.Entity<AppUser>().HasMany(u => u.Weight)
				.WithOne();

			builder.Entity<AppUser>().HasOne(u => u.HealthDeclaration)
				.WithOne(h => h.AppUser)
				.HasForeignKey<AppUser>(u => u.HealthDeclarationId);

			builder.Entity<AppUser>().HasOne(u => u.Menu)
				.WithOne(m => m.AppUser)
				.HasForeignKey<AppUser>(u => u.MenuId);

			builder.Entity<PlanDetails>().HasOne(pd => pd.Exercise)
				.WithMany(e => e.PlanDetails)
				.HasForeignKey(pd => pd.ExerciseId);

			builder.Entity<Plan>().HasMany(p => p.PlanDetails)
				.WithOne(pd => pd.Plan)
				.HasForeignKey(pd => pd.PlanId);

			builder.Entity<MuscleGroup>().HasMany(m => m.Exercises)
				.WithOne(e => e.MuscleGroup)
				.HasForeignKey(e => e.MuscleGroupId);

			builder.Entity<Menu>().HasMany(m => m.Meals)
				.WithOne(md => md.Menu)
				.HasForeignKey(md => md.MenuId);

			builder.Entity<IdentityRole<int>>().HasData([
				new IdentityRole<int>
				{
					Id = 1,
					Name = "Admin",
					NormalizedName = "ADMIN",
					ConcurrencyStamp = Guid.NewGuid().ToString()
				},
				new IdentityRole<int>
				{
					Id = 2,
					Name = "User",
					NormalizedName = "USER",
					ConcurrencyStamp = Guid.NewGuid().ToString()
				},
			]);

			builder.Entity<AppUser>().HasData([
				new AppUser(){
					Id = 1,
					FirstName="Avner",
					LastName="Hazan",
					Email = "a@gmail.com",
					NormalizedEmail = "A@GMAIL.COM",
					UserName = "a@gmail.com",
					NormalizedUserName = "A@GMAIL.COM",
					SecurityStamp = Guid.NewGuid().ToString(),
					PasswordHash = new PasswordHasher<AppUser>().HashPassword(null,"#Aa123456")
				},
				new AppUser(){
					Id = 2,
					FirstName="Daniel",
					LastName="Hazan",
					Email = "d@gmail.com",
					NormalizedEmail = "D@GMAIL.COM",
					UserName = "d@gmail.com",
					NormalizedUserName = "D@GMAIL.COM",
					SecurityStamp = Guid.NewGuid().ToString(),
					PasswordHash = new PasswordHasher<AppUser>().HashPassword(null,"#Aa123456")
				}
			]);

			builder.Entity<IdentityUserRole<int>>().HasData([
				new IdentityUserRole<int>(){
					RoleId = 1,
					UserId = 1
				},
				new IdentityUserRole<int>(){
					RoleId = 2,
					UserId = 2
				}
				]);

			builder.Entity<MuscleGroup>().HasData([
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
			]);

			builder.Entity<Exercise>().HasData([
				new Exercise(){
					Id = 1,
					Name = "Leg curls",
					MuscleGroupId = 7
				},
				new Exercise(){
					Id = 2,
					Name = "Bench press",
					MuscleGroupId = 1
				},
				new Exercise(){
					Id = 3,
					Name = "Hammer curls",
					MuscleGroupId = 3
				},
				new Exercise(){
					Id = 4,
					Name = "Skull Crushers",
					MuscleGroupId = 4
				},
				new Exercise(){
					Id = 5,
					Name = "Arnold press",
					MuscleGroupId = 6
				},
				new Exercise(){
					Id = 6,
					Name = "Plank",
					MuscleGroupId = 5
				},
				new Exercise(){
					Id = 7,
					Name = "Pull-down",
					MuscleGroupId = 2
				}
			]);

			builder.Entity<Plan>().HasData([
				new Plan(){
					Id = 1,
					Name = "Push",
					AppUserId = 2,
					IsCompleted = false,
				},
				new Plan(){
					Id = 2,
					Name = "Pull",
					AppUserId = 2,
					IsCompleted= false,
				}
				]);

			builder.Entity<PlanDetails>().HasData([
				new PlanDetails(){
					Id = 1,
					ExerciseId = 2,
					PlanId = 1,
					OrderInPlan = 1,
					Reps = 12,
					Sets = 4,
					CurrentWeight = 15,
					PreviousWeight = 12.5
				},
				new PlanDetails(){
					Id = 2,
					ExerciseId = 5,
					PlanId = 1,
					OrderInPlan = 2,
					Reps = 10,
					Sets = 4,
					CurrentWeight = null,
					PreviousWeight = null
				},
				new PlanDetails(){
					Id = 3,
					ExerciseId = 3,
					PlanId = 2,
					OrderInPlan = 1,
					Reps = 10,
					Sets = 4,
					CurrentWeight = null,
					PreviousWeight = null
				},
				new PlanDetails(){
					Id = 4,
					ExerciseId = 7,
					PlanId = 2,
					OrderInPlan = 2,
					Reps = 10,
					Sets = 3,
					CurrentWeight = null,
					PreviousWeight = null
				}
			]);
		}
	}
}
