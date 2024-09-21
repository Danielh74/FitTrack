using DAL.Models;
using FitTrackAPI.DTOs.Account;
using FitTrackAPI.Mappers;
using FitTrackAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitTrackAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenService tokenService) : ControllerBase
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
}

