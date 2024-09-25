using DAL.Helpers;
using DAL.Interfaces;
using FitTrackAPI.DTOs.ExerciseDetails;
using FitTrackAPI.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitTrackAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Roles = "Admin")]
	public class ExerciseDetailsController(IExerciseDetailsRepository exDetailsRepo, IExerciseRepository exerciseRepo) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var exDetailsList = await exDetailsRepo.GetAllAsync(query);
			if (exDetailsList is null)
			{
				return NoContent();
			}

			return Ok(exDetailsList.Select(ed => ed.ToDto()).ToList());
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var exDetails = await exDetailsRepo.GetByIdAsync(id);
			if (exDetails is null)
			{
				return NoContent();
			}

			return Ok(exDetails.ToDto());
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateExerciseDetailsDto exDetailsDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var isExists = await exerciseRepo.IsExists(exDetailsDto.ExerciseName);
			if (!isExists)
			{
				return NoContent();
			}

			var exDetailsModel = await exDetailsDto.ToModelFromCreate(exerciseRepo);
			await exDetailsRepo.CreateAsync(exDetailsModel);

			return CreatedAtAction(nameof(GetById), new { Id = exDetailsModel.Id }, exDetailsModel.ToDto());
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateExerciseDetailsRequestDto exDetailsDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var updatedModel = await exDetailsRepo.UpdateAsync(id, exDetailsDto.ToModelFromUpdate());
			if(updatedModel is null)
			{
				return NoContent();
			}

			return Ok(updatedModel.ToDto());
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var exDetails = await exDetailsRepo.GetByIdAsync(id);
			if (exDetails is null)
			{
				return NoContent();
			}
			await exDetailsRepo.DeleteAsync(exDetails);
			
			return Ok("Item deleted successfully");
		}
	}
}
