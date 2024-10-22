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
	[Authorize]
	public class PlanDetailsController(IPlanDetailsRepository repo) : ControllerBase
	{
		[HttpGet("admin")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetAll()
		{
			var planDetailsList = await repo.GetAllAsync();
			if (planDetailsList is null)
			{
				return NoContent();
			}

			return Ok(planDetailsList.Select(pd => pd.ToDto()));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			var planDetails = await repo.GetByIdAsync(id);
			if (planDetails is null)
			{
				return NoContent();
			}

			return Ok(planDetails.ToDto());
		}

		[HttpPost("admin")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Create([FromBody] CreatePlanDetailsDto dto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var planDetails = await repo.CreateAsync(dto.ToModelFromCreate());

			return Created();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePlanDetailsRequestDto dto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var planDetails = await repo.UpdateAsync(id,dto.ToModelFromUpdate());
			if(planDetails is null)
			{
				return NoContent();
			}
			return Ok(planDetails.ToDto());
		}

		[HttpPut("admin/{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AdminUpdate([FromRoute] int id, [FromBody] AdminUpdatePlanDetailsRequestDto dto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var planDetails = await repo.UpdateAsync(id, dto.ToModelFromUpdate());
			if (planDetails is null)
			{
				return NoContent();
			}
			return Ok(planDetails.ToDto());
		}

		[HttpDelete("admin/{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var planDetails = await repo.GetByIdAsync(id);
			if (planDetails is null)
			{
				return NoContent();
			}

			await repo.DeleteAsync(planDetails);

			return Ok("Item deleted successfully");
		}
	}
}
