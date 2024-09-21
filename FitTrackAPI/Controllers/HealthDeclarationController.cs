using DAL.Interfaces;
using FitTrackAPI.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitTrackAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HealthDeclarationController(IHealthDeclarationRepository repo) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var healthDecs = await repo.GetAllAsync();
			if(healthDecs is null)
			{
				return NotFound("There are no health declarations in the database");
			}

			return Ok(healthDecs.Select(h=> h.ToDto()));
		}

		//[HttpGet]
		//public async Task<IActionResult> GetByUserId(string userId)
		//{
			
		//	return Ok();
		//}
	}
}
