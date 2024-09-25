using DAL.Interfaces;
using FitTrackAPI.DTOs.MenuDTOs;
using FitTrackAPI.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FitTrackAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenusController(IMenuRepository repo) : ControllerBase
	{
		[HttpGet]
		[Authorize("Admin")]
		public async Task<IActionResult> GetAll()
		{
			var menus = await repo.GetAllAsync();
			if (menus is null) 
			{
				return NoContent();
			}

			return Ok(menus.Select(m=> m.ToListDto()));
		}

		[HttpGet("{id:int}")]
		[Authorize("Admin")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			var menu = await repo.GetByIdAsync(id);
			if (menu is null)
			{
				return NoContent();
			}

			return Ok(menu.ToDto());
		}

		[HttpGet("{userId}")]
		[Authorize]
		public async Task<IActionResult> GetById([FromRoute] string userId)
		{
			var menu = await repo.GetByUserIdAsync(userId);
			if (menu is null)
			{
				return NoContent();
			}

			var loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (menu.UserId != loggedInUserId || !User.IsInRole("Admin"))
			{
				return Forbid("You do not have premission to view this data");
			}

			return Ok(menu.ToDto());
		}

		[HttpPost]
		[Authorize("Admin")]
		public async Task<IActionResult> Create([FromBody] CreateMenuDto dto)
		{
            if (!ModelState.IsValid)
            {
				return BadRequest(ModelState);
            }

            var menu = await repo.CreateAsync(dto.ToModelFromCreate());

			return CreatedAtAction(nameof(GetById), new {Id = menu.Id}, menu.ToDto());
		}

		[HttpDelete("{id}")]
		[Authorize("Admin")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var menu = await repo.GetByIdAsync(id);
			if (menu is null)
			{
				return NoContent();
			}

			await repo.DeleteAsync(menu);

			return Ok("Item deleted successfully");
		}
	}
}
