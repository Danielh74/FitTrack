using DAL.Helpers;
using DAL.Interfaces;
using DAL.Models;
using FitTrackAPI.DTOs.Exercise;
using FitTrackAPI.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace FitTrackAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize( Roles = "Admin")]
	public class ExercisesController(IExerciseRepository exerciseRepo, IMuscleGroupRepository muscleGroupRepo) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var exercises = await exerciseRepo.GetAllAsync(query);

			return Ok(exercises.Select(e => e.ToDto()).ToList());
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var exercise = await exerciseRepo.GetByIdAsync(id);
			if (exercise is null)
			{
				return NotFound("No exercise with this id");
			}

			return Ok(exercise.ToDto());
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateExerciseDto exerciseDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (!await muscleGroupRepo.MuscleGroupExist(exerciseDto.MuscleGroupName))
			{
				return NotFound("Muscle group does not exist");
			}

			var exercise = await exerciseDto.ToModelFromCreate(muscleGroupRepo);

			await exerciseRepo.CreateAsync(exercise);

			return CreatedAtAction(nameof(GetById), new { Id = exercise.Id }, exercise.ToDto());
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateExerciseRequestDto exerciseDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (!await muscleGroupRepo.MuscleGroupExist(exerciseDto.MuscleGroupName))
			{
				return NotFound("Muscle group does not exist");
			}

			var exercise = await exerciseRepo.UpdateAsync(id, await exerciseDto.ToModelFromUpdate(muscleGroupRepo));

			if (exercise is null)
			{
				return NotFound($"Exercise with id: {id} was not found");
			}

			return Ok(exercise.ToDto());
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var exercise = await exerciseRepo.GetByIdAsync(id);
			if (exercise is null)
			{
				return NotFound($"Exercise with id: {id} was not found");
			}

			await exerciseRepo.DeleteAsync(exercise);

			return NoContent();
		}
	}
}
