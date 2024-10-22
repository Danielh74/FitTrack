using DAL.Interfaces;
using FitTrackAPI.DTOs.MealDTOs;
using FitTrackAPI.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitTrackAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Roles = "Admin")]
	public class MealsController(IMealRepository repo) : ControllerBase
	{
		[HttpGet("admin")]
		public async Task<IActionResult> GetAll()
		{
			var mealsList = await repo.GetAllAsync();
			if(mealsList is null)
			{
				return NoContent();
			}

			return Ok(mealsList.Select(md=> md.ToListDto()));
		}

		[HttpGet("admin/{id}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			var meal = await repo.GetByIdAsync(id);
			if (meal is null)
			{
				return NoContent();
			}

			return Ok(meal.ToDto());
		}

		[HttpPost("admin")]
		public async Task<IActionResult> Create([FromBody] CreateMealDto createDto)
		{
			if (ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var meal = await repo.CreateAsync(createDto.ToModelFromCreate());

			return CreatedAtAction(nameof(GetById), new { Id = meal.Id }, meal.ToDto());
		}

		[HttpPut("admin/{id}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMealRequestDto updateDto)
		{
			if (ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			
			var meal = await repo.UpdateAsync(id,updateDto.ToModelFromUpdate());
			if (meal is null)
			{
				return NoContent();
			}

			return Ok(meal.ToDto());
		}

		[HttpDelete("admin/{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{

			var meal = await repo.GetByIdAsync(id);
			if (meal is null)
			{
				return NoContent();
			}

			await repo.DeleteAsync(meal);

			return Ok("Item deleted successfully");
		}
	}
}
