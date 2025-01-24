using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Entities.Base.Entity;
using App.Domain.Core.Entities.Vehicle;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Ef.Repositories
{
    public class CarRepository : ICarRepository
    {

        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public Result Delete(int id)
        {
            var vehicleToDelete = _context.Cars.FirstOrDefault(x => x.Id == id);
            if (vehicleToDelete != null)
            {
                _context.Remove(vehicleToDelete);
                _context.SaveChanges();
                return new Result(true, "Vehicle Record Deleted Successfully");
            }
            return new Result(false, "Vehicle Not Found");
        }

        public Car Get(int id)
        {
            return _context.Cars.FirstOrDefault(x => x.Id == id);
        }

        public List<Car> GetAll()
        {
            return _context.Cars.
                Include(x => x.User).
                ToList();
        }

        public void Update(int id,Car car)
        {
            var vehicleToUpdate = _context.Cars.FirstOrDefault(x => x.Id == id);
            vehicleToUpdate.UserId = car.UserId;
            vehicleToUpdate.LicensePlate = car.LicensePlate;
            vehicleToUpdate.Year = car.Year;
            vehicleToUpdate.Make = car.Make;
            vehicleToUpdate.Model = car.Model;
            _context.SaveChanges();
        }
    }
}
