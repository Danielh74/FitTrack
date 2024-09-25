using DAL.Interfaces;
using DAL.Models;
using FitTrackAPI.DTOs.Health_Declaration;
using FitTrackAPI.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FitTrackAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HealthDeclarationsController(IHealthDeclarationRepository repo, UserManager<AppUser> userManager) : ControllerBase
	{
		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetAll()
		{
			var healthDecs = await repo.GetAllAsync();
			if(healthDecs.Count == 0)
			{
				return NotFound("There are no health declarations in the database");
			}

			return Ok(healthDecs.Select(h=> h.ToDto()));
		}

		[HttpGet("{userId}")]
		[Authorize(Roles ="Admin")]
		public async Task<IActionResult> GetByUserId(string userId)
		{
			var healthDec = await repo.GetByUserIdAsync(userId);

			if(healthDec is null)
			{
				return NotFound("Could not find health declaration with the user id");
			}

			return Ok(healthDec.ToDto());
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Create([FromBody]CreateHealthDeclarationDto createDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var userEmail = User.FindFirstValue(ClaimTypes.Email);
			if (userEmail is null)
			{
				return NotFound("Email of the user was not found in the claims");
			}

			var user = await userManager.FindByEmailAsync(userEmail);
			if (user is null)
			{
				return NotFound("User not found");
			}

			if (user.HealthDeclarationId is not null)
			{
				return BadRequest("User already has a health declaration");
			}

			var healthDec = createDto.ToModelFromCreate(user.Id);

			var result = await repo.CreateAsync(healthDec);

			user.HealthDeclarationId = result.Id;
			await userManager.UpdateAsync(user);

			return Created();
		}

		[HttpDelete("{id}")]
		[Authorize(Roles ="Admin")]
		public async Task<IActionResult> Delete(int id)
		{
			var healthDec = await repo.GetByIdAsync(id);
			if (healthDec is null)
			{
				return NotFound();
			}

			var user = await userManager.Users.FirstOrDefaultAsync(u => u.HealthDeclarationId == id);
			if (user is not null)
			{
				user.HealthDeclarationId = null;
				await userManager.UpdateAsync(user);
			}

			await repo.DeleteAsync(healthDec);

			return NoContent();
		}
	}
}
