using DAL.Interfaces;
using FitTrackAPI.DTOs.PlanDetailsDTOs;
using DAL.Helpers;
using FitTrackAPI.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitTrackAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlanDetailsController(IPlanDetailsRepository repo) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var planDetailsList = await repo.GetAllAsync();
			if (planDetailsList is null)
			{
				return NoContent();
			}

			return Ok(planDetailsList.Select(pd => pd.ToDto()));
		}

		[HttpGet("{planId}&{exDetailsId}")]
		public async Task<IActionResult> GetByKey([FromRoute]int planId, [FromRoute] int exDetailsId)
		{
			var planDetails = await repo.GetByKeyAsync(planId, exDetailsId);
			if (planDetails is null)
			{
				return NoContent();
			}

			return Ok(planDetails.ToDto());
		}

		[HttpGet("/planDetails/{planId}")]
		public async Task<IActionResult> GetByPlanId(int planId)
		{
			var planDetails = await repo.GetByPlanIdAsync(planId);
			if (planDetails is null)
			{
				return NoContent();
			}

			return Ok(planDetails.ToDto());
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreatePlanDetailsDto dto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var planDetails = await repo.CreateAsync(dto.ToModelFromCreate());

			return Created();
		}
	}
}
