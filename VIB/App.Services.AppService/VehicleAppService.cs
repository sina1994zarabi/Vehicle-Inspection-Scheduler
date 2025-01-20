using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.AppService
{
	public class VehicleAppService : IVehicleAppService
	{
		private readonly ICarService _carService;
        public VehicleAppService(ICarService carService)
        {
			_carService = carService;
        }

        public Car GetCarById(int carId)
		{
			return _carService.GetVehicle(carId);
		}
	}
}
