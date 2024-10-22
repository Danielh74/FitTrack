using DAL.Interfaces;
using DAL.Models;
using FitTrackAPI.DTOs.PlanDTOs;
using FitTrackAPI.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FitTrackAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class PlansController(IPlanRepository repo) : ControllerBase
	{
		[HttpGet("admin")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetAll()
		{
			var plans = await repo.GetAllAsync();
			if (plans is null)
			{
				return NoContent();
			}

			return Ok(plans.Select(p=> p.ToListDto()));

		}

		[HttpGet("admin/{id:int}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetById(int id)
		{
			var plan = await repo.GetByIdAsync(id);
			if (plan is null)
			{
				return NoContent();
			}

			return Ok(plan.ToPlanDto());

		}

		[HttpGet("{userId}")]
		public async Task<IActionResult> GetByUserId(int userId)
		{
			var validUserId = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier) ,out int currentUserId);

			if (!validUserId)
			{
				return BadRequest("Invalid user Id");
			}

			var plans = await repo.GetByUserIdAsync(userId);
			if (plans is null)
			{
				return NoContent();
			}

			if(!plans.TrueForAll(p=> p.AppUserId == currentUserId || !User.IsInRole("Admin")))
			{
				return Forbid();
			}

			return Ok(plans.Select(p=> p.ToPlanDto()));
		}

		[HttpPost("admin")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Create([FromBody] CreatePlanDto planDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var plan = await repo.CreateAsync(planDto.ToModelFromCreate());

			return CreatedAtAction(nameof(GetById), new {Id = plan.Id}, plan.ToPlanDto());
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePlanRequestDto planDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var plan = await repo.UpdateAsync(id,planDto.ToModelFromUpdate());
			if (plan is null)
			{
				return NoContent();
			}

			return Ok(plan.ToPlanDto());
		}

		[HttpDelete("admin/{id:int}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var plan = await repo.GetByIdAsync(id);
			if (plan is null)
			{
				return NoContent();
			}

			await repo.DeleteAsync(plan);

			return Ok("Item deleted successfully");
		}
	}
}
