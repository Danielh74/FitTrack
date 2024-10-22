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
	[Authorize]
	public class HealthDeclarationsController(IHealthDeclarationRepository repo, UserManager<AppUser> userManager) : ControllerBase
	{
		[HttpGet("admin")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetAll()
		{
			var healthDecs = await repo.GetAllAsync();
			if(healthDecs is null)
			{
				return NoContent();
			}

			return Ok(healthDecs.Select(h=> h.ToDto()));
		}

		[HttpGet("admin/{userId}")]
		[Authorize(Roles ="Admin")]
		public async Task<IActionResult> GetByUserId(int userId)
		{
			var healthDec = await repo.GetByUserIdAsync(userId);

			if(healthDec is null)
			{
				return NoContent();
			}

			return Ok(healthDec.ToDto());
		}

		[HttpPost("admin")]
		public async Task<IActionResult> Create([FromBody]CreateHealthDeclarationDto createDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var userEmail = User.FindFirstValue(ClaimTypes.Email);
			if (userEmail is null)
			{
				return NoContent();
			}

			var user = await userManager.FindByEmailAsync(userEmail);
			if (user is null)
			{
				return NoContent();
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

		[HttpDelete("admin/{id}")]
		[Authorize(Roles ="Admin")]
		public async Task<IActionResult> Delete(int id)
		{
			var healthDec = await repo.GetByIdAsync(id);
			if (healthDec is null)
			{
				return NoContent();
			}

			var user = await userManager.Users.FirstOrDefaultAsync(u => u.HealthDeclarationId == id);
			if (user is not null)
			{
				user.HealthDeclarationId = null;
				await userManager.UpdateAsync(user);
			}

			await repo.DeleteAsync(healthDec);

			return Ok("Item deleted successfully");
		}
	}
}
