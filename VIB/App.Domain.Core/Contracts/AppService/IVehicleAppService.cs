using App.Domain.Core.Entities.Base.Entity;
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
        //string ValidatePlateNumber(string plateNumber);
        //List<Car> ListOwnerCars(int userId);
        Task<Car> GetCarDetails(int carId);
        Task<List<Car>> GetAllCars();
        Task EditCarInfo(int id,Car car);
        Task<Result> DeleteCarRecordInfo(int carId);
        Task AddNewCar(Car car);
        void LogRejectedCar(RejectedCar car);
    }
}
