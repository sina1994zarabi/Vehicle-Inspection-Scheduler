using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public void ChangeVehicleInfo(int id,Car car)
        {
             _carRepository.Update(id,car);
        }

        public Result DeleteVehicleRecord(int id)
        {
            return _carRepository.Delete(id);
        }

        public List<Car> GetAllVehicles()
        {
            return _carRepository.GetAll();
        }

        public Car GetVehicle(int id)
        {
            return _carRepository.Get(id);
        }

        public void Register(Car car)
        {
             _carRepository.Add(car);
        }
    }
}
