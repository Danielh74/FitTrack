﻿using DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace FitTrackAPI.DTOs.AccountDTOs
{
	public class UpdateUserRequestDto
	{
		public string City { get; set; } = string.Empty;

		[Required]
		[Range(5, 120, ErrorMessage = "Please enter a valid age between 5 and 120.")]
		public int Age { get; set; }

		[Required]
		[MinLength(3)]
		public string Goal { get; set; } = string.Empty;

		[Required]
		[Range(50, 300, ErrorMessage = "Please enter a valid height between 50 cm and 300 cm.")]
		public int Height { get; set; }

		[Required]
		[Range(1, 300, ErrorMessage = "Please enter a valid weight up to 300 kg.")]
		public required Weight Weight { get; set; }

		[Range(0, double.MaxValue, ErrorMessage = "Only positive inputs are allowed")]
		public double NeckCircumference { get; set; } = 0;

		[Range(0, double.MaxValue, ErrorMessage = "Only positive inputs are allowed")]
		public double PecsCircumference { get; set; } = 0;

		[Range(0, double.MaxValue, ErrorMessage = "Only positive inputs are allowed")]
		public double WaistCircumference { get; set; } = 0;

		[Range(0, double.MaxValue, ErrorMessage = "Only positive inputs are allowed")]
		public double AbdominalCircumference { get; set; } = 0;

		[Range(0, double.MaxValue, ErrorMessage = "Only positive inputs are allowed")]
		public double HipsCircumference { get; set; } = 0;

		[Range(0, double.MaxValue, ErrorMessage = "Only positive inputs are allowed")]
		public double ThighsCircumference { get; set; } = 0;

		[Range(0, double.MaxValue, ErrorMessage = "Only positive inputs are allowed")]
		public double ArmCircumference { get; set; } = 0;
	}
}
