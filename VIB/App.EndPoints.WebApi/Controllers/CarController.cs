﻿using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Entities.Vehicle;
using App.Infra.Data.Ef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System.Drawing;

namespace App.EndPoints.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarController : ControllerBase
	{
		private readonly AppDbContext _appDbContext;
		private readonly IVehicleAppService _vehicleAppService;
		private const string API_KEY_HEADER = "X-API-KEY";

		public CarController(AppDbContext appDbContext,
							IVehicleAppService vehicleAppService)
		{
			_appDbContext = appDbContext;
			_vehicleAppService = vehicleAppService;
		}

		private bool ValidateApiKey()
		{
			if (!Request.Headers.TryGetValue(API_KEY_HEADER, out StringValues extractedApiKey))
			{
				return false;
			}

			var validApiKey = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.Build()
				.GetValue<string>("ApiKey");

			return validApiKey == extractedApiKey;
		}


		[HttpGet("{id}")]
		public async Task<ActionResult<Car>> GetCar(int id) 
		{
			//if (!ValidateApiKey()) return Unauthorized();
			//var car = await _appDbContext.Cars.FindAsync(id);
			var car = await _vehicleAppService.GetCarDetails(id);
			if (car == null) return NotFound("خودرو یافت نشد");
			return car;
		}

		[HttpGet]
		public async Task<ActionResult<List<Car>>> GetCars()
		{
			//if(!ValidateApiKey()) return Unauthorized();
			//return await _appDbContext.Cars.
			//	ToListAsync();
			return await _vehicleAppService.GetAllCars();
        }

		[HttpPut("{id}")]
		public async Task<IActionResult> EditCar(int id,[FromBody] Car car)
		{
			if (!ValidateApiKey()) return Unauthorized("شما مجاز به انجام این کار نیستید.");
			if (id != car.Id) return BadRequest();
			#region DbContextAccess
			//var carToEdit = await _appDbContext.Cars.FindAsync(id);
			//if (carToEdit == null) return NotFound("خودرو یافت نشد");
			//carToEdit.LicensePlate = car.LicensePlate;
			//carToEdit.UserId = car.UserId;
			//carToEdit.Year = car.Year;
			//carToEdit.LastInspectionDate = car.LastInspectionDate;
			//carToEdit.Model = car.Model;
			//await _appDbContext.SaveChangesAsync();
			#endregion
			await _vehicleAppService.EditCarInfo(id, car);
			return Ok("ویرایش مشخصات خودرو با موفقیت انجام شد.");
		}

		[HttpPost]
		public async Task<IActionResult> PostCar(Car car)
		{
			//if (!ValidateApiKey()) return Unauthorized();
			//_appDbContext.Cars.Add(car);
			//await _appDbContext.SaveChangesAsync();
			await _vehicleAppService.AddNewCar(car);
			return Ok("ثبت خودرو جدید با موفقیت انجام شد.");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			//if (!ValidateApiKey()) return Unauthorized();
			#region DbContextAccess
			//var carToDelete = await _appDbContext.Cars.FindAsync(id);
			//if (carToDelete == null) return NotFound();
			//_appDbContext.Cars.Remove(carToDelete);
			//await _appDbContext.SaveChangesAsync();
			#endregion
			var result = await _vehicleAppService.DeleteCarRecordInfo(id);
			return Ok(result.Message);
		}

	}
}
