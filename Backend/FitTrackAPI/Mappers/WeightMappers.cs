using DAL.Interfaces;
using DAL.Models;
using FitTrackAPI.DTOs.Exercise;
using FitTrackAPI.DTOs.WeightDTOs;

namespace FitTrackAPI.Mappers
{
	public static class WeightMappers
	{
		public static WeightDto ToDto(this Weight weightModel)
		{
			return new WeightDto
			{
				Value = weightModel.Value,
				TimeStamp = weightModel.TimeStamp,
			};
		}

		public static Weight ToModelFromUpdate(this UpdateWeightRequestDto weightDto)
		{
			var creationDate = DateTime.UtcNow.ToShortDateString();

			return new Weight
			{
				Value = weightDto.Value,
				TimeStamp = creationDate
			};
		}
	}
}
