using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FitTrackAPI.Services;

public class TokenService
{
	private readonly IConfiguration config;
	private readonly UserManager<AppUser> userManager;
	private readonly SymmetricSecurityKey key;
	public TokenService(IConfiguration _config, UserManager<AppUser> _userManager)
	{
		config = _config;
		userManager = _userManager;
		key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SigningKey"]));
	}

	public async Task<string> CreateTokenAsync(AppUser user)
	{
		var claims = new List<Claim>
		{
			new Claim(JwtRegisteredClaimNames.NameId,user.Id.ToString()),
			new Claim(JwtRegisteredClaimNames.Email,user.Email)
		};

		if (await userManager.IsInRoleAsync(user, "Admin"))
		{
			claims.Add(new Claim(ClaimTypes.Role, "Admin"));
		}

		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(claims),
			Expires = DateTime.Now.AddDays(1),
			SigningCredentials = creds,
			Issuer = config["JWT:Issuer"],
			Audience = config["JWT:Audience"]
		};

		var tokenHandler = new JwtSecurityTokenHandler();

		var token = tokenHandler.CreateToken(tokenDescriptor);

		return tokenHandler.WriteToken(token);
	}
}