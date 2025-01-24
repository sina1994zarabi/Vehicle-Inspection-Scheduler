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
        private readonly IRejectedCarService _rejectedCarService;
        public VehicleAppService(ICarService carService, IRejectedCarService rejectedCarService)
        {
            _carService = carService;
            _rejectedCarService = rejectedCarService;
        }

        public void AddNewCar(Car car)
        {
            _carService.Register(car);
        }

        public void DeleteCarRecordInfo(int carId)
        {
           _carService.DeleteVehicleRecord(carId);
        }

        public void EditCarInfo(Car car)
        {
            _carService.ChangeVehicleInfo(car.Id,car);
        }

        public Car GetCarDetails(int carId)
        {
            return _carService.GetVehicle(carId);
        }

        public List<Car> ListOwnerCars(int userId)
        {
            return _carService.GetAllVehicles().
                    Where(x => x.UserId == userId).ToList();
        }

        public void LogRejectedCar(RejectedCar car)
        {
            _rejectedCarService.AddRejectedCar(car);
        }

        public string ValidatePlateNumber(string plateNumber)
        {
            try
            {
                var car = _carService.GetAllVehicles().
                        Where(x => x.LicensePlate == plateNumber).
                        Single();
                if (car != null)
                    return "شماره پلاک معتبر است";
                return string.Empty;
            } catch (Exception ex)
            {
                return string.Empty;
            }
        }


    }
}
