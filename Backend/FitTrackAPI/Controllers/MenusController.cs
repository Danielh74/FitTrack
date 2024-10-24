﻿using DAL.Interfaces;
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
	[Authorize]
	public class MenusController(IMenuRepository repo) : ControllerBase
	{
		[HttpGet("admin")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetAll()
		{
			var menus = await repo.GetAllAsync();
			if (menus is null) 
			{
				return NoContent();
			}

			return Ok(menus.Select(m=> m.ToListDto()));
		}

		[HttpGet("{userId}")]
		public async Task<IActionResult> GetById([FromRoute] int userId)
		{
			var menu = await repo.GetByUserIdAsync(userId);
			if (menu is null)
			{
				return NoContent();
			}

			var validLoggedInUserId = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier),out int loggedInUserId);

			if (!validLoggedInUserId) 
			{
				return BadRequest("Invalid user Id");
			}

			if (menu.UserId != loggedInUserId || !User.IsInRole("Admin"))
			{
				return Forbid();
			}

			return Ok(menu.ToDto());
		}

		[HttpPost("admin")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Create([FromBody] CreateMenuDto dto)
		{
            if (!ModelState.IsValid)
            {
				return BadRequest(ModelState);
            }

            var menu = await repo.CreateAsync(dto.ToModelFromCreate());

			return CreatedAtAction(nameof(GetById), new {Id = menu.Id}, menu.ToDto());
		}

		[HttpDelete("admin/{id}")]
		[Authorize(Roles = "Admin")]
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
