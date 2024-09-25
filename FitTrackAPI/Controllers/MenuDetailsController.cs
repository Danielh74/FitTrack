using DAL.Interfaces;
using FitTrackAPI.DTOs.MenuDetailsDTOs;
using FitTrackAPI.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitTrackAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Roles = "Admin")]
	public class MenuDetailsController(IMenuDetailsRepository repo) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var menuDetailsList = await repo.GetAllAsync();
			if(menuDetailsList is null)
			{
				return NoContent();
			}

			return Ok(menuDetailsList.Select(md=> md.ToListDto()));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			var menuDetails = await repo.GetByIdAsync(id);
			if (menuDetails is null)
			{
				return NoContent();
			}

			return Ok(menuDetails.ToDto());
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateMenuDetailsDto createDto)
		{
			if (ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var menuDetails = await repo.CreateAsync(createDto.ToModelFromCreate());

			return CreatedAtAction(nameof(GetById), new { Id = menuDetails.Id }, menuDetails.ToDto());
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMenuDetailsRequestDto updateDto)
		{
			if (ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			
			var menuDetails = await repo.UpdateAsync(id,updateDto.ToModelFromUpdate());
			if (menuDetails is null)
			{
				return NotFound();
			}

			return Ok(menuDetails.ToDto());
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{

			var menuDetails = await repo.GetByIdAsync(id);
			if (menuDetails is null)
			{
				return NotFound();
			}

			await repo.DeleteAsync(menuDetails);

			return Ok();
		}
	}
}
