using DAL.Helpers;
using DAL.Interfaces;
using FitTrackAPI.DTOs.MuscleGroup;
using FitTrackAPI.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitTrackAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Roles ="Admin")]
	public class MuscleGroupsController(IMuscleGroupRepository repo) : ControllerBase
	{
		[HttpGet("admin")]
		public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var muscleGroups = await repo.GetAllAsync(query);

			return Ok(muscleGroups.Select(m => m.ToDto()).ToList());
		}

		[HttpGet("admin/{id:int}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var muscleGroup = await repo.GetByIdAsync(id);
			if (muscleGroup is null)
			{
				return NoContent();
			}

			return Ok(muscleGroup.ToDto());
		}

		[HttpPut("admin/{id:int}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMuscleGroupRequestDto mgDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			
			var updatedMuscleGroup = await repo.UpdateAsync(id,mgDto.ToModelFromUpdate());
			if(updatedMuscleGroup is null)
			{
				return NoContent();
			}

			return Ok(updatedMuscleGroup.ToDto());
		}

		[HttpPost("admin")]
		public async Task<IActionResult> Create(CreateMuscleGroupDto musclGroupDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var muscleGroup = await repo.CreateAsync(musclGroupDto.ToModelFromCreate());

			return CreatedAtAction(nameof(GetById),new {Id = muscleGroup.Id }, muscleGroup.ToDto());
		}

		[HttpDelete("admin/{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var muscleGroup = await repo.GetByIdAsync(id);
			if(muscleGroup is null)
			{
				return NoContent();
			}

			await repo.DeleteAsync(muscleGroup);

			return Ok("Item deleted successfully");
		}
	}
}
