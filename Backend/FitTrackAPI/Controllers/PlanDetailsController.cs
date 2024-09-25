using DAL.Interfaces;
using FitTrackAPI.DTOs.PlanDetailsDTOs;
using DAL.Helpers;
using FitTrackAPI.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FitTrackAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Roles = "Admin")]
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
		public async Task<IActionResult> GetByKey([FromRoute] int planId, [FromRoute] int exDetailsId)
		{
			var planDetails = await repo.GetByKeyAsync(planId, exDetailsId);
			if (planDetails is null)
			{
				return NoContent();
			}

			return Ok(planDetails.ToDto());
		}

		[HttpGet("{planId}")]
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

		[HttpPut("{planId}&{exDetailsId}")]
		public async Task<IActionResult> Update([FromRoute] int planId, [FromRoute] int exDetailsId, [FromBody] UpdatePlanDetailsRequestDto dto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var planDetails = await repo.UpdateAsync(planId,exDetailsId,dto.ToModelFromUpdate());
			if(planDetails is null)
			{
				return NoContent();
			}
			return Ok(planDetails.ToDto());
		}

		[HttpDelete("{planId}&{exDetailsId}")]
		public async Task<IActionResult> Delete([FromRoute] int planId, [FromRoute] int exDetailsId)
		{
			var planDetails = await repo.GetByKeyAsync(planId, exDetailsId);
			if (planDetails is null)
			{
				return NoContent();
			}

			await repo.DeleteAsync(planDetails);

			return Ok("Item deleted successfully");
		}
	}
}
