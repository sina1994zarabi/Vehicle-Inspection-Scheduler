using App.Domain.Core.Entities.Vehicle;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppService
{
	public interface IVehicleAppService
	{
        string ValidatePlateNumber(string plateNumber);
        List<Car> ListOwnerCars(int userId);
        Car GetCarDetails(int carId);
        void EditCarInfo(Car car);
        void DeleteCarRecordInfo(int carId);
        void AddNewCar(Car car);
        void LogRejectedCar(RejectedCar car);
    }
}
