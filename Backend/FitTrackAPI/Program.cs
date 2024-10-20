
using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using DAL.Services;
using FitTrackAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

namespace FitTrackAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("DataContext")
			?? throw new InvalidOperationException("Connection string 'DataContext' not found.")));

			//Add identity services to DI. (Enables UserManager, SignInManager)
			builder.Services.AddIdentity<AppUser, IdentityRole<int>>(options =>
			{
				options.User.RequireUniqueEmail = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequiredLength = 8;
				options.Password.RequireUppercase = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireDigit = true;
			}).AddEntityFrameworkStores<AppDbContext>()
			.AddDefaultTokenProviders();

			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme =
				options.DefaultChallengeScheme =
				options.DefaultForbidScheme =
				options.DefaultScheme =
				options.DefaultSignOutScheme =
				options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidIssuer = builder.Configuration["JWT:Issuer"],
					ValidateAudience = true,
					ValidAudience = builder.Configuration["JWT:Audience"],
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(
						 Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]))
				};
			});

			// Add services to the container.
			builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
			builder.Services.AddScoped<IMuscleGroupRepository, MuscleGroupRepository>();
			builder.Services.AddScoped<IHealthDeclarationRepository, HealthDeclarationRepository>();
			builder.Services.AddScoped<IPlanRepository, PlanRepository>();
			builder.Services.AddScoped<IPlanDetailsRepository, PlanDetailsRepository>();
			builder.Services.AddScoped<IMenuRepository,MenuRepository>();
			builder.Services.AddScoped<IMealRepository, MealRepository>();
			builder.Services.AddScoped<TokenService>();
			builder.Services.AddHostedService<ResetPlansCompletedService>();

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
					builder.Services.AddSwaggerGen(option =>
					{
						option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
						option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
						{
							In = ParameterLocation.Header,
							Description = "Please enter a valid token",
							Name = "Authorization",
							Type = SecuritySchemeType.Http,
							BearerFormat = "JWT",
							Scheme = "Bearer"
						});
						option.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference
						{
							Type=ReferenceType.SecurityScheme,
							Id="Bearer"
						}
					},
					new string[]{}
				}
			});
					});

			var corsPolicy = "CorsPolicy";
			builder.Services.AddCors(options =>
			{
				options.AddPolicy(corsPolicy, policy =>
				{
					policy.WithOrigins(
						"http://localhost:3000",
						"http://localhost:5173",
						"http://localhost:5174"
						)
					.AllowAnyHeader()
					.AllowAnyMethod()
					.AllowCredentials();
				});
			});

			var app = builder.Build();

			app.UseCors(corsPolicy);

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
