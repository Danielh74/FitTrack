using DAL.Models;
using FitTrackAPI.DTOs.AccountDTOs;
using FitTrackAPI.DTOs.WeightDTOs;
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
			return BadRequest("Email already in use");
		}

		var roleResult = await userManager.AddToRoleAsync(user, "User");
		if (!roleResult.Succeeded)
		{
			return StatusCode(statusCode: 500, roleResult.Errors);
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

		var user = await userManager.Users
			.Include(u=>u.Weight)
			.Include(u=>u.Plans)
			.Include(u=> u.Menu)
				.ThenInclude(m=>m.Meals)
			.FirstOrDefaultAsync(u=>u.Email == loginDto.Email);
		if (user is null)
		{
			return Unauthorized("User does not exist.");
		}

		var signInResult = await signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
		if (!signInResult.Succeeded)
		{
			return Unauthorized("User does not exist.");
		}

		var token = await tokenService.CreateTokenAsync(user);

		return Ok(new { Token = token, User = user.ToDto() });
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

		var user = await userManager.Users
			.Include(u=> u.Weight)
			.FirstOrDefaultAsync(u=> u.Email == userEmail);
		if (user is null)
		{
			return NotFound("User not found");
		}

		double updatedBodyFat = 0;
		if (userDto.Height > 0
			&& userDto.WaistCircumference > 0
			&& userDto.HipsCircumference > 0
			&& userDto.NeckCircumference > 0)
		{
			updatedBodyFat = Utils.BodyFatPercentage(
				 userDto.WaistCircumference,
				 userDto.HipsCircumference,
				 userDto.NeckCircumference,
				 userDto.Height,
				 user.Gender);
		}

		var updatedWeight = new UpdateWeightRequestDto { Value = userDto.Weight }.ToModelFromUpdate();

		if (user.Weight.Count == 0 ||
			user.Weight[user.Weight.Count - 1].Value != updatedWeight.Value ||
			user.Weight[user.Weight.Count - 1].TimeStamp != updatedWeight.TimeStamp)
		{
			user.Weight.Add(updatedWeight);
		}

		user.City = userDto.City;
		user.Age = userDto.Age;
		user.Height = userDto.Height;
		user.Goal = userDto.Goal;
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

		return Ok(user.ToDto());
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

	[HttpDelete("admin/{id}")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> DeleteById(int id)
	{
		var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
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

	[HttpGet("admin")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> GetAll()
	{
		var users = await userManager.Users.ToListAsync();

		if (users.Count == 0)
		{
			return NoContent();
		}

		return Ok(users.Select(u => u.ToListDto()));
	}

	[HttpGet("{userId}")]
	[Authorize]
	public async Task<IActionResult> GetById(int userId)
	{
		var validUserId = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int currentUserId);
		if (!validUserId)
		{
			return NotFound($"User with id: {userId} was not found");
		}

		if ((currentUserId != userId) && (!User.IsInRole("Admin")))
		{
			return Forbid();
		}

		var user = await userManager.Users
			.Include(u => u.Weight)
			.Include(u => u.Menu)
				.ThenInclude(m => m.Meals)
			.Include(u => u.Plans)
				.ThenInclude(p => p.PlanDetails)
					.ThenInclude(pd => pd.Exercise)
			.FirstOrDefaultAsync(u => u.Id == userId);

		if (user is null)
		{
			return NotFound("User was not found.");
		}

		return Ok(user.ToDto());
	}
}

