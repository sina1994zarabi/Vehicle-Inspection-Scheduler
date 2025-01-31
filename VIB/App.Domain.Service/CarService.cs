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

        public async Task ChangeVehicleInfo(int id,Car car)
        {
             await _carRepository.Update(id,car);
        }

        public async Task<Result> DeleteVehicleRecord(int id)
        {
            return await _carRepository.Delete(id);
        }

        public async Task<List<Car>> GetAllVehicles()
        {
            return await _carRepository.GetAll();
        }

        public async Task<Car> GetVehicle(int id)
        {
            return await _carRepository.Get(id);
        }

        public async Task Register(Car car)
        {
             await _carRepository.Add(car);
        }
    }
}
