using DAL.Models;
using FitTrackAPI.DTOs.AccountDTOs;
using FitTrackAPI.Helpers;
using FitTrackAPI.Mappers;
using FitTrackAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace FitTrackAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController(
	UserManager<AppUser> userManager,
	SignInManager<AppUser> signInManager,
	TokenService tokenService) : ControllerBase
{
	[HttpPost("register")]
	public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}

		var user = registerDto.ToUser();
		var result = await userManager.CreateAsync(user, registerDto.Password);
		if (!result.Succeeded)
		{
			return BadRequest(result.Errors);
		}

		var roleResult = await userManager.AddToRoleAsync(user, "User");
		if (!roleResult.Succeeded)
		{
			return StatusCode(500, roleResult.Errors);
		}

		return Ok();
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}

		var user = await userManager.FindByEmailAsync(loginDto.Email);
		if (user is null)
		{
			return Unauthorized();
		}

		var signInResult = await signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
		if (!signInResult.Succeeded)
		{
			return Unauthorized();
		}

		var token = await tokenService.CreateTokenAsync(user);

		return Ok(new { Token = token });
	}

	[HttpPut]
	[Authorize]
	public async Task<IActionResult> Update([FromBody] UpdateUserRequestDto userDto)
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

		double updatedBodyFat = 0;
		if (userDto.Height > 0 && userDto.Weight > 0)
		{
			updatedBodyFat = Utils.BodyFatPercentage(
				 userDto.WaistCircumference,
				 userDto.HipsCircumference,
				 userDto.NeckCircumference,
				 userDto.Height,
				 user.Gender);
		}

		user.City = userDto.City;
		user.Age = userDto.Age;
		user.Height = userDto.Height;
		user.Weight = userDto.Weight;
		user.NeckCircumference = userDto.NeckCircumference;
		user.PecsCircumference = userDto.PecsCircumference;
		user.WaistCircumference = userDto.WaistCircumference;
		user.AbdominalCircumference = userDto.AbdominalCircumference;
		user.HipsCircumference = userDto.HipsCircumference;
		user.ThighsCircumference = userDto.ThighsCircumference;
		user.ArmCircumference = userDto.ArmCircumference;
		user.BodyFatPrecentage = updatedBodyFat;

		var result = await userManager.UpdateAsync(user);
		if (!result.Succeeded)
		{
			return StatusCode(500, result.Errors);
		}

		return Ok(result);
	}

	[HttpDelete]
	[Authorize]
	public async Task<IActionResult> Delete()
	{
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

		var result = await userManager.DeleteAsync(user);
		if (!result.Succeeded)
		{
			return StatusCode(500, "Failed to delete user");
		}
		return Ok("User was deleted successfully");
	}

	[HttpGet]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetAll()
	{
		var users = await userManager.Users.ToListAsync(); ;

		if (users.Count == 0)
		{
			return NoContent();
		}

		return Ok(users.Select(u => u.ToListDto()));
	}

	[HttpGet("{id}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetById(string id)
	{
		//Check if can remove the includes after creating plans
		var user = await userManager.Users
			.Include(u => u.Menu)
				.ThenInclude(m => m.MenuDetails)
			.Include(u => u.Plans)
				.ThenInclude(p => p.PlanDetails)
					.ThenInclude(pd => pd.ExerciseDetails)
						.ThenInclude(ed => ed.Exercise)
			.FirstOrDefaultAsync(u => u.Id == id);

		if (user is null)
		{
			return NotFound();
		}

		return Ok(user.ToDto());
	}
}

