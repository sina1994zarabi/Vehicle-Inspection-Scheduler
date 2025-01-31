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

        public async Task Add(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }

        public async Task<Result> Delete(int id)
        {
            var vehicleToDelete = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (vehicleToDelete != null)
            {
                _context.Remove(vehicleToDelete);
                await _context.SaveChangesAsync();
                return new Result(true, "Vehicle Record Deleted Successfully");
            }
            return new Result(false, "Vehicle Not Found");
        }

        public async Task<Car> Get(int id)
        {
            return await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Car>> GetAll()
        {
            return await _context.Cars.
                ToListAsync();
        }

        public async Task Update(int id,Car car)
        {
            var vehicleToUpdate = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            vehicleToUpdate.UserId = car.UserId;
            vehicleToUpdate.LicensePlate = car.LicensePlate;
            vehicleToUpdate.Year = car.Year;
            vehicleToUpdate.Make = car.Make;
            vehicleToUpdate.Model = car.Model;
            await _context.SaveChangesAsync();
        }
    }
}
